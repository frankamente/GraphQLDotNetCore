using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GraphQL.Types;
using GraphQLDotNetCore.Models;

namespace GraphQLDotNetCore
{
    public class EmployeeCertificationType : ObjectGraphType<Certification>
    {
        public EmployeeCertificationType()
        {
            Field(t => t.Id);
            Field(t => t.Title);
            Field(t => t.Month, nullable: true);
            Field(t => t.Year, nullable: true);
            Field(t => t.Provider);
        }
    }
}
