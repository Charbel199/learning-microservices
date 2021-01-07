using System.Threading.Tasks;

namespace GithubService.Jobs
{
    public interface IGithubProjectsJob
    {
        Task<string> GetProjects();
    }
}