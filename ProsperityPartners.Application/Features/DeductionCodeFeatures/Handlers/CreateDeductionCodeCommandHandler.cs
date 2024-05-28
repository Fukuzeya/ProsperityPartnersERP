using AutoMapper;
using MediatR;
using ProsperityPartners.Application.Contracts.Persistance;
using ProsperityPartners.Application.Features.DeductionCodeFeatures.Commands;
using ProsperityPartners.Application.Shared.DeductionCodeDTOs;
using ProsperityPartners.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProsperityPartners.Application.Features.DeductionCodeFeatures.Handlers
{
    public class CreateDeductionCodeCommandHandler : IRequestHandler<CreateDeductionCodeCommand, DeductionCodeDto>
    {
        private readonly IMapper _mapper;
        private readonly IRepositoryManager _repositoryManager;

        public CreateDeductionCodeCommandHandler(IMapper mapper, IRepositoryManager repositoryManager)
        {
            _mapper = mapper;
            _repositoryManager = repositoryManager;
        }
        public async Task<DeductionCodeDto> Handle(CreateDeductionCodeCommand request, CancellationToken cancellationToken)
        {
            // check if company exists
            await _repositoryManager.Company.GetCompanyAndCheckIfItExists(request.companyId, trackChanges: false);
            var deductionCodeEntiry = _mapper.Map<DeductionCode>(request.CreateDeductionCodeDto);
            await _repositoryManager.DeductionCode.CreateDeductionCode(deductionCodeEntiry);
            _repositoryManager.SaveChanges();
            var deductionCodeDto = _mapper.Map<DeductionCodeDto>(deductionCodeEntiry);
            return deductionCodeDto;
        }
    }
}
