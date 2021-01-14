using GithubService.Models.ResponseModels.QueryResponseModels;
using MediatR;

namespace GithubService.Models.RequestModels.QueryRequestModels
{
    public class GetProjectByIdRequestModel: IRequest<GetProjectByIdResponseModel>
    {
        public int Id { get; set; }
    }
}