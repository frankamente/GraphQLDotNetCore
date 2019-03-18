using GraphQL.DataLoader;
using GraphQL.Types;
using GraphQLDotNetCore.Models;

namespace GraphQLDotNetCore
{
    public class EmployeeType : ObjectGraphType<Employee>
    {
        public EmployeeType(ICertificationRepository certificationRepository, IDataLoaderContextAccessor dataLoaderContextAccessor)
        {
            Field(a => a.Id);
            Field(a => a.Name);
            Field(a => a.Email);
            Field(a => a.Mobile);
            Field(a => a.Company).DeprecationReason("Very old");
            Field(a => a.Address).Description("Company Address");
            Field(a => a.ShortDescription);
            Field(a => a.LongDescription);
            Field<ListGraphType<EmployeeCertificationType>>(
                "certifications",
                resolve: context =>
                {
                    var loader = dataLoaderContextAccessor.Context.GetOrAddCollectionBatchLoader<long, Certification>(
                        "GetCertificationByEmployee", certificationRepository.GetCertificationByEmployee);

                    return loader.LoadAsync(context.Source.Id);
                });
        }
    }
}
