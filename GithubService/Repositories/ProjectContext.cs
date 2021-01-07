using GithubService.Models;
using Microsoft.EntityFrameworkCore;

namespace GithubService.Repositories
{
    public class ProjectContext: DbContext
    {
        public ProjectContext(DbContextOptions<ProjectContext> opt): base(opt)
        {
            
        }
        
        public DbSet<Project> Projects { get; set; }
        
    }
}