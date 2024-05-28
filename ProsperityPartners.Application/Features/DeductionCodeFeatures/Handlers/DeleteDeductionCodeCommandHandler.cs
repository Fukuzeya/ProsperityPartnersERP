using AutoMapper;
using MediatR;
using ProsperityPartners.Application.Contracts.Persistance;
using ProsperityPartners.Application.Features.DeductionCodeFeatures.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProsperityPartners.Application.Features.DeductionCodeFeatures.Handlers
{
    public class DeleteDeductionCodeCommandHandler : IRequestHandler<DeleteDeductionCodeCommand, Unit>
    {
        private readonly IMapper _mapper;
        private readonly IRepositoryManager _repositoryManager;

        public DeleteDeductionCodeCommandHandler(IMapper mapper, IRepositoryManager repositoryManager)
        {
            _mapper = mapper;
            _repositoryManager = repositoryManager;
        }
        public async Task<Unit> Handle(DeleteDeductionCodeCommand request, CancellationToken cancellationToken)
        {
            // check if company exists
            await _repositoryManager.Company.GetCompanyAndCheckIfItExists(request.companyId, trackChanges: false);
            var deductionCode = await _repositoryManager.DeductionCode.GetDeductionCodeAsync(request.Id,trackChanges:true);
            _repositoryManager.DeductionCode.DeleteDeductionCode(deductionCode);
            _repositoryManager.SaveChanges();
            return Unit.Value;
        }
    }
}
