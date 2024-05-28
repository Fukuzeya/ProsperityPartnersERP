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
    public class GetDeductionCodeBatchesQueryHandler : IRequestHandler<GetDeductionCodeBatchesQuery, IEnumerable<BatchDto>>
    {
        private readonly IMapper _mapper;
        private readonly IRepositoryManager _repositoryManager;

        public GetDeductionCodeBatchesQueryHandler(IMapper mapper, IRepositoryManager repositoryManager)
        {
            _mapper = mapper;
            _repositoryManager = repositoryManager;
        }
        public async Task<IEnumerable<BatchDto>> Handle(GetDeductionCodeBatchesQuery request, CancellationToken cancellationToken)
        {
            var batches = await _repositoryManager.Batch.GetDeductionCodeBatchesAsync(request.deductionCodeId, trackChanges: false);
            var batchesDto = _mapper.Map<IEnumerable<BatchDto>>(batches);
            return batchesDto;
        }
    }
}
