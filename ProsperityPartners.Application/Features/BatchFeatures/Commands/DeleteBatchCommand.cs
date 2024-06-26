﻿using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProsperityPartners.Application.Features.BatchFeatures.Commands
{
    public record DeleteBatchCommand(Guid Id) : IRequest<Unit>;
}
