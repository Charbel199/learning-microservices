using System;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using GithubService.Models;
using GithubService.Models.RequestModels.QueryRequestModels;
using GithubService.Models.ResponseModels.QueryResponseModels;
using GithubService.Repositories;
using MediatR;

namespace GithubService.Handlers.QueryHandlers
{
    public class GetProjectByIdQueryHandler: IRequestHandler<GetProjectByIdRequestModel, GetProjectByIdResponseModel>
    {
        private readonly IProjectRepository _projectRepository;
        private readonly IMapper _mapper;

        public GetProjectByIdQueryHandler(
            IProjectRepository projectRepository,
            IMapper mapper)
        {
            _projectRepository = projectRepository;
            _mapper = mapper;
        }
        
        public async Task<GetProjectByIdResponseModel> Handle(GetProjectByIdRequestModel request, CancellationToken cancellationToken)
        {
            Project project = await _projectRepository.GetProjectById(request.Id);
            GetProjectByIdResponseModel responseModel = new GetProjectByIdResponseModel()
            {
                Project = project
            };
            return responseModel;
        }
    }
}