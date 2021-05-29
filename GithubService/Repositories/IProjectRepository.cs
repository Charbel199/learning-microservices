using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using GithubService.Models;

namespace GithubService.Repositories
{
    public interface IProjectRepository
    {
        Task<List<Project>> GetAllProjects();
        Task<Project> GetProjectById(int id);
        Task<bool> AddProject(Project project);
        Task<bool> AddAllProjects(List<Project> projects);
        Task<bool> DeleteAllProjects();
    }
}