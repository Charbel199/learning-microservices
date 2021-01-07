using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using AutoMapper;
using GithubService.DTOs;
using GithubService.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;

namespace GithubService.Jobs
{
    public class GithubProjectsJob: IGithubProjectsJob
    {
        private readonly IMapper _mapper;
        private readonly IConfiguration _config;

        public GithubProjectsJob(
            IMapper mapper,
            IConfiguration config)
        {
            _mapper = mapper;
            _config = config;
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
            

            Console.WriteLine("Finished Github projects fetch job ...");
            return "Success";
        }
        
    }
}