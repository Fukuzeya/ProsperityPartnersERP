using AutoMapper;
using MediatR;
using ProsperityPartners.Application.Contracts.Persistance;
using ProsperityPartners.Application.Features.RecordFeatures.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProsperityPartners.Application.Features.RecordFeatures.Handlers
{
    public class DeleteRecordCommandHandler : IRequestHandler<DeleteRecordCommand, Unit>
    {
        private readonly IMapper _mapper;
        private readonly IRepositoryManager _repositoryManager;

        public DeleteRecordCommandHandler(IMapper mapper, IRepositoryManager repositoryManager)
        {
            _mapper = mapper;
            _repositoryManager = repositoryManager;
        }
        public async Task<Unit> Handle(DeleteRecordCommand request, CancellationToken cancellationToken)
        {
            var record = await _repositoryManager.Record.GetRecordAsync(request.Id,trackChanges:true);
            _repositoryManager.Record.DeleteRecord(record);
            _repositoryManager.SaveChanges();
            return Unit.Value;
        }
    }
}
