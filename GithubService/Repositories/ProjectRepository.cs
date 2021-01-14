using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GithubService.Models;
using Microsoft.EntityFrameworkCore;

namespace GithubService.Repositories
{
    public class ProjectRepository: IProjectRepository
    {
        private readonly ProjectContext _context;

        public ProjectRepository(ProjectContext context)
        {
            _context = context;
        }
        
        

        public async Task<List<Project>> GetAllProjects()
        {
            List<Project> projects = await _context.Projects.ToListAsync();
            return projects;
        }

        public async Task<Project> GetProjectById(int id)
        {
            return await _context.Projects.FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task<bool> AddProject(Project project)
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
            await _context.Projects.AddAsync(project);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> AddAllProjects(List<Project> projects)
        {
            Console.WriteLine("Adding all projects");
            
            if (projects == null)
            {
                throw new ArgumentNullException(nameof(projects));
            }
            await _context.AddRangeAsync(projects);
            _context.SaveChanges();
            return true;
        }

        public async Task<bool> DeleteAllProjects()
        {
            _context.Projects.RemoveRange(_context.Projects);
            _context.SaveChanges();
            return true;
        }
    }
}