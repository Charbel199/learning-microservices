using System;
using System.ComponentModel.DataAnnotations;

namespace GithubService.DTOs
{
    public class GithubApiResponse
    {
        [Key]
        public int Id { get; set; }
        
        public string Name { get; set; }
        
        public string Description { get; set; }
        
        public string Created_At { get; set; }

        public int Size { get; set; }
        
        public string Language { get; set; }
        
        public int Stargazers_Count { get; set; }
        
        public int Forks_Count { get; set; }
       
        public string Html_Url { get; set; }
    }
}