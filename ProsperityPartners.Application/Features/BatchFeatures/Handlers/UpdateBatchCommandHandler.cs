using AutoMapper;
using MediatR;
using ProsperityPartners.Application.Contracts.Persistance;
using ProsperityPartners.Application.Features.BatchFeatures.Commands;
using ProsperityPartners.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProsperityPartners.Application.Features.BatchFeatures.Handlers
{
    public class UpdateBatchCommandHandler : IRequestHandler<UpdateBatchCommand, Unit>
    {
        private readonly IMapper _mapper;
        private readonly IRepositoryManager _repositoryManager;

        public UpdateBatchCommandHandler(IMapper mapper, IRepositoryManager repositoryManager)
        {
            _mapper = mapper;
            _repositoryManager = repositoryManager;
        }
        public async Task<Unit> Handle(UpdateBatchCommand request, CancellationToken cancellationToken)
        {
            // Check if Deduction Code for the batch exists
            await _repositoryManager.DeductionCode.DeductionCodeExists(request.deductionCodeId);
            var batchEntity = _mapper.Map<Batch>(request.UpdateBatchDto);
            _repositoryManager.Batch.UpdateBatch(batchEntity);
            _repositoryManager.SaveChanges();
            return Unit.Value;
        }
    }
}
