using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProsperityPartners.Domain.Exceptions
{
    public sealed class DeductionCodeNotFoundException : NotFoundException
    {
        public DeductionCodeNotFoundException(Guid Id) 
            : base($"The deductionCode with id: {Id} does not exist in the database.")
        {
        }
    }
}
