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
    public class GetRecordQueryHandler : IRequestHandler<GetRecordQuery, RecordDto>
    {
        private readonly IMapper _mapper;
        private readonly IRepositoryManager _repositoryManager;

        public GetRecordQueryHandler(IMapper mapper, IRepositoryManager repositoryManager)
        {
            _mapper = mapper;
            _repositoryManager = repositoryManager;
        }
        public async Task<RecordDto> Handle(GetRecordQuery request, CancellationToken cancellationToken)
        {
            var record = await _repositoryManager.Record.GetRecordAsync(request.Id,trackChanges: false);
            var recordDto = _mapper.Map<RecordDto>(record);
            return recordDto;
        }
    }
}
