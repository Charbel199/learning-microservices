using System;
using System.ComponentModel.DataAnnotations;

namespace GithubService.Models
{
    public class Project
    {
        [Key]
        public int Id { get; set; }
        
        public string Name { get; set; }
        
        public string Description { get; set; }
        
        public string CreatedAt { get; set; }

        public int Size { get; set; }
        
        public string Language { get; set; }
        
        public int Stars { get; set; }
        
        public int Forks { get; set; }
       
        public string Link { get; set; }
        
    }
}