using System.Collections.Generic;
using GithubService.Models.ResponseModels.CommandResponseModels;
using MediatR;

namespace GithubService.Models.RequestModels.CommandRequestModels
{
    public class AddAllProjectsRequestModel: IRequest<AddAllProjectsResponseModel>
    {
        public List<Project> Projects { get; set; }
    }
}