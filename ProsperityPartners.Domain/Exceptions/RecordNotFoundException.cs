using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProsperityPartners.Domain.Exceptions
{
    public partial class RecordNotFoundException : NotFoundException
    {
        public RecordNotFoundException(Guid Id) 
            : base($"The record with id: {Id} does not exist in the database.")
        {
        }
    }
}
