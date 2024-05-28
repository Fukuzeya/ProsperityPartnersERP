using AutoMapper;
using MediatR;
using ProsperityPartners.Application.Contracts.Persistance;
using ProsperityPartners.Application.Features.DeductionCodeFeatures.Queries;
using ProsperityPartners.Application.Shared.DeductionCodeDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProsperityPartners.Application.Features.DeductionCodeFeatures.Handlers
{
    public class GetCompanyDeductionCodesQueryHandler : IRequestHandler<GetCompanyDeductionCodesQuery, IEnumerable<DeductionCodeDto>>
    {
        private readonly IMapper _mapper;
        private readonly IRepositoryManager _repositoryManager;

        public GetCompanyDeductionCodesQueryHandler(IMapper mapper, IRepositoryManager repositoryManager)
        {
            _mapper = mapper;
            _repositoryManager = repositoryManager;
        }
        public async Task<IEnumerable<DeductionCodeDto>> Handle(GetCompanyDeductionCodesQuery request, CancellationToken cancellationToken)
        {
            var deductionCodes = await _repositoryManager.DeductionCode
                .GetCompanyDeductionCodesAsync(request.companyId, trackChanges: false);
            var deductionCodesDto = _mapper.Map<IEnumerable<DeductionCodeDto>>(deductionCodes);
            return deductionCodesDto;
        }
    }
}
