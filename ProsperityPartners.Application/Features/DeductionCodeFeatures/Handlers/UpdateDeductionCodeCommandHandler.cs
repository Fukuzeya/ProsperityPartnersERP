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
    public class UpdateDeductionCodeCommandHandler : IRequestHandler<UpdateDeductionCodeCommand, Unit>
    {
        private readonly IMapper _mapper;
        private readonly IRepositoryManager _repositoryManager;

        public UpdateDeductionCodeCommandHandler(IMapper mapper,IRepositoryManager repositoryManager)
        {
            _mapper = mapper;
            _repositoryManager = repositoryManager;
        }
        public async Task<Unit> Handle(UpdateDeductionCodeCommand request, CancellationToken cancellationToken)
        {
            await _repositoryManager.Company.GetCompanyAndCheckIfItExists(request.companyId, trackChanges: false);
            var deductionCodeEntity = _mapper.Map<DeductionCode>(request.UpdateDeductionCodeDto);
            _repositoryManager.DeductionCode.UpdateDeductionCode(deductionCodeEntity);
            _repositoryManager.SaveChanges();
            return Unit.Value;
        }
    }
}
