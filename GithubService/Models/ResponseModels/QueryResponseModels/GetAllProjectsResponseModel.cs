using System.Collections.Generic;

namespace GithubService.Models.ResponseModels.QueryResponseModels
{
    public class GetAllProjectsResponseModel
    {
        public List<Project> Projects { get; set; }
    }
}