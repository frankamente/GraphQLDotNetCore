using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GraphQLDotNetCore.Models;

namespace GraphQLDotNetCore
{
    public interface ICertificationRepository
    {
        Task<ILookup<long, Certification>> GetCertificationByEmployee(IEnumerable<long> employeeIds);
    }
}
