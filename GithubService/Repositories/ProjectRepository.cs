using System;
using System.Collections.Generic;
using System.Linq;
using GithubService.Models;

namespace GithubService.Repositories
{
    public class ProjectRepository: IProjectRepository
    {
        private readonly ProjectContext _context;

        public ProjectRepository(ProjectContext context)
        {
            _context = context;
        }
        public bool SaveChanges()
        {
            return (_context.SaveChanges() >= 0);
        }

        public List<Project> GetAllProjects()
        {
            return _context.Projects.ToList();
        }

        public Project GetProjectById(int id)
        {
            return _context.Projects.FirstOrDefault(p => p.Id == id);
        }

        public void AddProject(Project project)
        {
            if (project == null)
            {
                throw new ArgumentNullException(nameof(project));
            }
            Console.WriteLine("IN ADD PROJECT");
            Console.WriteLine("Current project: ");
            Console.WriteLine(project.Id);
            Console.WriteLine(project.Language);
            Console.WriteLine(project.Size);
            _context.Projects.Add(project);
            _context.SaveChanges();
        }

        public void AddAllProjects(List<Project> projects)
        {
            if (projects == null)
            {
                throw new ArgumentNullException(nameof(projects));
            }
            
            _context.AddRange(projects);
            _context.SaveChanges();
        }

        public void DeleteAllProjects()
        {
            _context.Projects.RemoveRange(_context.Projects);
            _context.SaveChanges();
        }
    }
}