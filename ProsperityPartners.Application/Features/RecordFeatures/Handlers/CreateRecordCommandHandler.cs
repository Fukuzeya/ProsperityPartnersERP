using AutoMapper;
using MediatR;
using ProsperityPartners.Application.Contracts.Persistance;
using ProsperityPartners.Application.Features.RecordFeatures.Commands;
using ProsperityPartners.Application.Shared.RecordDTOs;
using ProsperityPartners.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProsperityPartners.Application.Features.RecordFeatures.Handlers
{
    public class CreateRecordCommandHandler : IRequestHandler<CreateRecordCommand, RecordDto>
    {
        private readonly IMapper _mapper;
        private readonly IRepositoryManager _repositoryManager;

        public CreateRecordCommandHandler(IMapper mapper, IRepositoryManager repositoryManager)
        {
            _mapper = mapper;
            _repositoryManager = repositoryManager;
        }
        public async Task<RecordDto> Handle(CreateRecordCommand request, CancellationToken cancellationToken)
        {
            var recordEntity = _mapper.Map<Record>(request.CreateRecordDto);
            await _repositoryManager.Record.CreateRecord(recordEntity);
            _repositoryManager.SaveChanges();
            var recordDto = _mapper.Map<RecordDto>(recordEntity);
            return recordDto;
        }
    }
}
