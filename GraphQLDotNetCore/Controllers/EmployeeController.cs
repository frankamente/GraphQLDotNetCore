using GraphQL.Client;
using GraphQL.Common.Request;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using GraphQLDotNetCore.Models;

namespace GraphQLDotNetCore.Controllers
{
    [Route("Employee")]
    public class EmployeeController : Controller
    {
        [HttpGet]
        public async Task<List<Employee>> Get()
        {
            using (GraphQLClient graphQLClient = new GraphQLClient("https://localhost:44302/graphql"))
            {
                var query = new GraphQLRequest
                {
                    Query = @"   
                        { employees   
                            { name   
                              email    
                              certifications  
                                 { title }  
                            }  
                        }",
                };
                var response = await graphQLClient.PostAsync(query);
                return response.GetDataFieldAs<List<Employee>>("employees");
            }
        }

        [HttpGet("{id}")]
        public async Task<Employee> Get(int id)
        {
            using (GraphQLClient graphQLClient = new GraphQLClient("https://localhost:44302/graphql"))
            {
                var query = new GraphQLRequest
                {
                    Query = @"   
                        query employeeQuery($employeeId: ID!)  
                        { employee(id: $employeeId)   
                            { id name email   
                            }  
                        }",
                    Variables = new { employeeId = id }
                };
                var response = await graphQLClient.PostAsync(query);
                return response.GetDataFieldAs<Employee>("employee");
            }
        }
    }
}