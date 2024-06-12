using AutoMapper;
using MediatR;
using ProsperityPartners.Application.Contracts.Persistance;
using ProsperityPartners.Application.Features.RecordFeatures.Commands;
using ProsperityPartners.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProsperityPartners.Application.Features.RecordFeatures.Handlers
{
    public class UpdateRecordCommandHandler : IRequestHandler<UpdateRecordCommand, Unit>
    {
        private readonly IMapper _mapper;
        private readonly IRepositoryManager _repositoryManager;

        public UpdateRecordCommandHandler(IMapper mapper, IRepositoryManager repositoryManager)
        {
            _mapper = mapper;
            _repositoryManager = repositoryManager;
        }
        public async Task<Unit> Handle(UpdateRecordCommand request, CancellationToken cancellationToken)
        {
            await _repositoryManager.Batch.BatchExists(request.UpdateRecordDto.BatchId);
            var record = _mapper.Map<Record>(request.UpdateRecordDto);
            _repositoryManager.Record.UpdateRecord(record);
            _repositoryManager.SaveChanges();
            return Unit.Value;
        }
    }
}
