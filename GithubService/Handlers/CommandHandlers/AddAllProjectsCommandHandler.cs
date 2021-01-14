using System.Collections.Generic;
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
    
    public class AddAllProjectsCommandHandler: IRequestHandler<AddAllProjectsRequestModel,AddAllProjectsResponseModel>
    {
        private readonly IProjectRepository _projectRepository;
        private readonly IMapper _mapper;

        public AddAllProjectsCommandHandler(
            IProjectRepository projectRepository,
            IMapper mapper)
        {
            _projectRepository = projectRepository;
            _mapper = mapper;
        }
        public async Task<AddAllProjectsResponseModel> Handle(AddAllProjectsRequestModel request, CancellationToken cancellationToken)
        {
            List<Project> projects = new List<Project>();
            request.Projects.ForEach(x => projects.Add( _mapper.Map<Project>(x)));
            _projectRepository.AddAllProjects(projects);
            AddAllProjectsResponseModel response = new AddAllProjectsResponseModel()
            {
                IsSuccess = true
            };
            return response;

        }
    }
}