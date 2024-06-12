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
    public record GetDeductionCodeQueryHandler : IRequestHandler<GetDeductionCodeQuery, DeductionCodeDto>
    {
        private readonly IMapper _mapper;
        private readonly IRepositoryManager _repositoryManager;

        public GetDeductionCodeQueryHandler(IMapper mapper, IRepositoryManager repositoryManager)
        {
            _mapper = mapper;
            _repositoryManager = repositoryManager;
        }
        public async Task<DeductionCodeDto> Handle(GetDeductionCodeQuery request, CancellationToken cancellationToken)
        {
            await _repositoryManager.DeductionCode.GetDeductionCodeAsync(request.Id,trackChanges:false);
            var deductionCode = await _repositoryManager.DeductionCode
                .GetDeductionCodeAsync(request.Id, trackChanges: false);
            var deductionCodeDto = _mapper.Map<DeductionCodeDto>(deductionCode);
            return deductionCodeDto;
        }
    }
}
