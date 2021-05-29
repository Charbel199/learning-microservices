using GithubService.Models.ResponseModels.CommandResponseModels;
using MediatR;

namespace GithubService.Models.RequestModels.CommandRequestModels
{
    public class AddProjectRequestModel : IRequest<AddProjectResponseModel>
    {
        public Project Project { get; set; }
    }
}