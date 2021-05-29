using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using AutoMapper;
using GithubService.DTOs;
using GithubService.Models;
using GithubService.Models.RequestModels.CommandRequestModels;
using GithubService.Models.ResponseModels.CommandResponseModels;
using GithubService.Repositories;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;

namespace GithubService.Jobs
{
    public class GithubProjectsJob: IGithubProjectsJob
    {
        private readonly IMapper _mapper;
        private readonly IConfiguration _config;
        private readonly IProjectRepository _projectRepository;
        private readonly IMediator _mediator;

        public GithubProjectsJob(
            IMapper mapper,
            IConfiguration config,
            IProjectRepository projectRepository,
            IMediator mediator)
        {
            _mapper = mapper;
            _config = config;
            _projectRepository = projectRepository;
            _mediator = mediator;
        }
        static readonly HttpClient client = new HttpClient();
        
        public async Task<string> GetProjects()
        {
            try
            {
                Console.WriteLine("Starting Github projects fetch job ...");
                Console.WriteLine("Fetching projects ...");
                List<Project> projects = await FetchProjects();
                Console.WriteLine("Fetched projects ...");

                //Delete old projects:
                DeleteAllProjectsRequestModel deleteModel = new DeleteAllProjectsRequestModel();
                DeleteAllProjectsResponseModel deleteResponse = await _mediator.Send(deleteModel);
                Console.WriteLine("Projects removed ...");
                Console.WriteLine("Delete response: " + deleteResponse.IsSuccess);
                //Add updated projects:
                AddAllProjectsRequestModel addModel = new AddAllProjectsRequestModel()
                {
                    Projects = projects
                };
                AddAllProjectsResponseModel addResponse = await _mediator.Send(addModel);

                Console.WriteLine("Projects added ...");
                Console.WriteLine("Add response: " + addResponse.IsSuccess);


                Console.WriteLine("Finished Github projects fetch job ...");
                return "Success";
            }
            catch (Exception e)
            {
                Console.WriteLine("Caught an error: "+e.Message);
                return "Failed";
            }
        }

        public async Task<List<Project>> FetchProjects()
        {
            string endpoint = _config["GithubJob:GithubApi"];
            var request = new HttpRequestMessage
            {
                RequestUri = new Uri(endpoint),
                Method = HttpMethod.Get,
                Headers =
                {
                    {
                        "User-Agent", "request"
                    }
                }
            };
            Console.WriteLine("In fetch projects");
            HttpResponseMessage response = await client.SendAsync(request);
            Console.WriteLine("Status code: " +response.StatusCode);
            string apiResponse = await response.Content.ReadAsStringAsync();
            List<GithubApiResponse> githubProjects = JsonConvert.DeserializeObject<List<GithubApiResponse>>(apiResponse);
            List<Project> projects = _mapper.Map<List<Project>>(githubProjects);
            return projects;
        }
        
    }
}