using AutoMapper;
using MediatR;
using ProsperityPartners.Application.Contracts.Persistance;
using ProsperityPartners.Application.Features.BatchFeatures.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProsperityPartners.Application.Features.BatchFeatures.Handlers
{
    public class DeleteBatchCommandHandler : IRequestHandler<DeleteBatchCommand, Unit>
    {
        private readonly IMapper _mapper;
        private readonly IRepositoryManager _repositoryManager;

        public DeleteBatchCommandHandler(IMapper mapper, IRepositoryManager repositoryManager)
        {
            _mapper = mapper;
            _repositoryManager = repositoryManager;
        }
        public async Task<Unit> Handle(DeleteBatchCommand request, CancellationToken cancellationToken)
        {
            await _repositoryManager.Batch.BatchExists(request.Id);
            var batchEntity = await _repositoryManager.Batch.GetBatchAsync(request.Id, true);
            _repositoryManager.Batch.DeleteBatch(batchEntity);
            _repositoryManager.SaveChanges();
            return Unit.Value;
        }
    }
}
