using System;
using System.Collections.Generic;
using System.Linq;
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
    public class GetAllProjectsQueryHandler: IRequestHandler<GetAllProjectsRequestModel, GetAllProjectsResponseModel>
    {
        private readonly IProjectRepository _projectRepository;
        private readonly IMapper _mapper;

        public GetAllProjectsQueryHandler(
            IProjectRepository projectRepository,
            IMapper mapper)
        {
            _projectRepository = projectRepository;
            _mapper = mapper;
        }
        public async Task<GetAllProjectsResponseModel> Handle(GetAllProjectsRequestModel request, CancellationToken cancellationToken)
        {
            List<Project> projects = await _projectRepository.GetAllProjects();
            GetAllProjectsResponseModel responseModel = new GetAllProjectsResponseModel()
            {
                Projects = projects
            };
            return responseModel;
        }
    }
}