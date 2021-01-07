using System.Collections;
using System.Collections.Generic;
using GithubService.Models;

namespace GithubService.Repositories
{
    public interface IProjectRepository
    {
        bool SaveChanges();
        IEnumerable<Project> GetAllProjects();
        Project GetProjectById(int id);
        void AddProject(Project project);
        void AddAllProjects(List<Project> projects);
        void DeleteAllProjects();
    }
}