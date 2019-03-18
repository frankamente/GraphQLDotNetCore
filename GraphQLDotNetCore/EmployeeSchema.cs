using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GraphQL;
using GraphQL.Types;

namespace GraphQLDotNetCore
{
    public class EmployeeSchema : Schema
    {
        public EmployeeSchema(IDependencyResolver resolver) : base(resolver)
        {
            Query = resolver.Resolve<EmployeeQuery>();
        }
    }
}
