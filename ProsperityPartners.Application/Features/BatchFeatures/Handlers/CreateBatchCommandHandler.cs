using AutoMapper;
using MediatR;
using ProsperityPartners.Application.Contracts.Persistance;
using ProsperityPartners.Application.Features.BatchFeatures.Commands;
using ProsperityPartners.Application.Shared.BatchDTOs;
using ProsperityPartners.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProsperityPartners.Application.Features.BatchFeatures.Handlers
{
    public class CreateBatchCommandHandler : IRequestHandler<CreateBatchCommand, BatchDto>
    {
        private readonly IMapper _mapper;
        private readonly IRepositoryManager _repositoryManager;

        public CreateBatchCommandHandler(IMapper mapper, IRepositoryManager repositoryManager)
        {
            _mapper = mapper;
            _repositoryManager = repositoryManager;
        }
        public async Task<BatchDto> Handle(CreateBatchCommand request, CancellationToken cancellationToken)
        {
            await _repositoryManager.DeductionCode.DeductionCodeExists(request.deductionCodeId);
            var batchEntity = _mapper.Map<Batch>(request.CreateBatchDto);
            await _repositoryManager.Batch.CreateBatchAsync(batchEntity);
            _repositoryManager.SaveChanges();
            var batchDto = _mapper.Map<BatchDto>(batchEntity);
            return batchDto;
        }
    }
}
