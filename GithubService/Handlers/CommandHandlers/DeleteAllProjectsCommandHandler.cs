using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;
using GithubService.Models.RequestModels.CommandRequestModels;
using GithubService.Models.ResponseModels.CommandResponseModels;
using GithubService.Repositories;
using MediatR;

namespace GithubService.Handlers.CommandHandlers
{
    public class DeleteAllProjectsCommandHandler: IRequestHandler<DeleteAllProjectsRequestModel,DeleteAllProjectsResponseModel>
    {
        private readonly IProjectRepository _projectRepository;

        public DeleteAllProjectsCommandHandler(
            IProjectRepository projectRepository)
        {
            _projectRepository = projectRepository;
        }
        public async Task<DeleteAllProjectsResponseModel> Handle(DeleteAllProjectsRequestModel request, CancellationToken cancellationToken)
        {
            await _projectRepository.DeleteAllProjects();
            DeleteAllProjectsResponseModel responseModel = new DeleteAllProjectsResponseModel()
            {
                IsSuccess = true
            };
            return responseModel;
        }
    }
}