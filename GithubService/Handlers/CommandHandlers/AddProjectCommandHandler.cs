using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using GithubService.Models;
using GithubService.Models.RequestModels.CommandRequestModels;
using GithubService.Models.ResponseModels.CommandResponseModels;
using GithubService.Repositories;
using MediatR;

namespace GithubService.Handlers.CommandHandlers
{
    public class AddProjectCommandHandler: IRequestHandler<AddProjectRequestModel, AddProjectResponseModel>
    {
        private readonly IProjectRepository _projectRepository;
        private readonly IMapper _mapper;

        public AddProjectCommandHandler(
            IProjectRepository projectRepository,
            IMapper mapper)
        {
            _projectRepository = projectRepository;
            _mapper = mapper;
        }
        
        public async Task<AddProjectResponseModel> Handle(AddProjectRequestModel request, CancellationToken cancellationToken)
        {
            _projectRepository.AddProject(_mapper.Map<Project>(request));
            AddProjectResponseModel response = new AddProjectResponseModel
            {
                Id = request.Id,
                IsSuccess = true
            };
            return response;
        }
    }
}