using AutoMapper;
using MediatR;
using ProsperityPartners.Application.Contracts.Persistance;
using ProsperityPartners.Application.Features.BatchFeatures.Queries;
using ProsperityPartners.Application.Shared.BatchDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProsperityPartners.Application.Features.BatchFeatures.Handlers
{
    public class GetBatchQueryHandler : IRequestHandler<GetBatchQuery, BatchDto>
    {
        private readonly IMapper _mapper;
        private readonly IRepositoryManager _repositoryManager;

        public GetBatchQueryHandler(IMapper mapper, IRepositoryManager repositoryManager)
        {
            _mapper = mapper;
            _repositoryManager = repositoryManager;
        }
        public async Task<BatchDto> Handle(GetBatchQuery request, CancellationToken cancellationToken)
        {
            var batchEntity = await _repositoryManager.Batch.GetBatchAsync(request.Id, trackChanges: false);
            var batchDto = _mapper.Map<BatchDto>(batchEntity);
            return batchDto;
        }
    }
}
