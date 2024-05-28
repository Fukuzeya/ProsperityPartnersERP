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
    public class GetCompanyRecordsQueryHandler : IRequestHandler<GetCompanyRecordsQuery, IEnumerable<RecordDto>>
    {
        private readonly IMapper _mapper;
        private readonly IRepositoryManager _repositoryManager;

        public GetCompanyRecordsQueryHandler(IMapper mapper, IRepositoryManager repositoryManager)
        {
            _mapper = mapper;
            _repositoryManager = repositoryManager;
        }
        public async Task<IEnumerable<RecordDto>> Handle(GetCompanyRecordsQuery request, CancellationToken cancellationToken)
        {
            await _repositoryManager.Company.GetCompanyAndCheckIfItExists(request.companyId, trackChanges: false);
            var companyRecords = await _repositoryManager.Record
                .GetCompanyRecordsAsync(request.companyId, trackchanges: false);
            var companyRecordsDto = _mapper.Map<IEnumerable<RecordDto>>(companyRecords);
            return companyRecordsDto;
        }
    }
}
