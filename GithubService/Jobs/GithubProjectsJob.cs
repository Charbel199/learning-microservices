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
            Console.WriteLine("Starting Github projects fetch job ...");
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
            
            HttpResponseMessage response = await client.SendAsync(request);
            Console.WriteLine("Status code: " +response.StatusCode);
            string apiResponse = await response.Content.ReadAsStringAsync();
            List<GithubApiResponse> githubProjects = JsonConvert.DeserializeObject<List<GithubApiResponse>>(apiResponse);
            List<Project> projects = _mapper.Map<List<Project>>(githubProjects);
            //Delete old projects:
            _projectRepository.DeleteAllProjects();
            //Add updated projects:
            AddAllProjectsRequestModel requestModel = new AddAllProjectsRequestModel()
            {
                Projects = projects
            };
            AddAllProjectsResponseModel requestResponse = await _mediator.Send(requestModel);
           // _projectRepository.AddAllProjects(projects);
            Console.WriteLine("Request response: " + requestResponse.IsSuccess);
            Console.WriteLine("Finished Github projects fetch job ...");
            return "Success";
        }
        
    }
}