using System.Collections.Generic;
using System.Threading.Tasks;
using GithubService.Models;

namespace GithubService.Jobs
{
    public interface IGithubProjectsJob
    {
        Task<string> GetProjects();
        Task<List<Project>> FetchProjects();
    }
}