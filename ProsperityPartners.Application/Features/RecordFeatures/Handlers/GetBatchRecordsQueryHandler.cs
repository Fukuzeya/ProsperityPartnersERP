using AutoMapper;
using MediatR;
using ProsperityPartners.Application.Contracts.Persistance;
using ProsperityPartners.Application.Features.RecordFeatures.Queries;
using ProsperityPartners.Application.Shared.RecordDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProsperityPartners.Application.Features.RecordFeatures.Handlers
{
    public class GetBatchRecordsQueryHandler : IRequestHandler<GetBatchRecordsQuery, IEnumerable<RecordDto>>
    {
        private readonly IMapper _mapper;
        private readonly IRepositoryManager _repositoryManager;

        public GetBatchRecordsQueryHandler(IMapper mapper, IRepositoryManager repositoryManager)
        {
            _repositoryManager = repositoryManager;
            _mapper = mapper;
        }
        public async Task<IEnumerable<RecordDto>> Handle(GetBatchRecordsQuery request, CancellationToken cancellationToken)
        {
            // Check if batch exists
            await _repositoryManager.Batch.BatchExists(request.batchId);
            var batchRecords = await _repositoryManager.Record
                .GetBatchRecordsAsync(request.batchId, trackChanges: false);
            var batchRecordsDto = _mapper.Map<IEnumerable<RecordDto>>(batchRecords);
            return batchRecordsDto;

        }
    }
}
