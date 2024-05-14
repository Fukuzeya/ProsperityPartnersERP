﻿using ProsperityPartners.Application.Contracts.Persistance;
using ProsperityPartners.Domain.Entities;
using ProsperityPartners.Persistance.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProsperityPartners.Persistance.Repository
{
    public class RecordRepository : RepositoryBase<Record>, IRecordRepository
    {
        public RecordRepository(RepositoryContext repositoryContext) : 
            base(repositoryContext)
        {
        }
    }
}
