using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProsperityPartners.Domain.Exceptions
{
    public partial class BatchNotFoundException : NotFoundException
    {
        public BatchNotFoundException(Guid Id) 
            : base($"The Batch with id: {Id} does not exist in the database.")
        {
        }
    }
}
