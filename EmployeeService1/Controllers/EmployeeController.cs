using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using EmployeeAccess;

namespace EmployeeService1.Controllers
{
    public class EmployeeController : ApiController
    {
        public IEnumerable<Employee> Get()
        {
            using (DemoEntities entity = new DemoEntities())
            {
                return entity.Employees.ToList();
            }
        }


        public HttpResponseMessage Get(int id)
        {
            using (DemoEntities entity = new DemoEntities())
            {
                var Result = entity.Employees.FirstOrDefault(e => e.ID == id);
                if (Result != null)
                {
                    return Request.CreateResponse(HttpStatusCode.OK, Result);
                }
                else
                {
                    return Request.CreateResponse(HttpStatusCode.NotFound, "Employee With Id="+id.ToString() + "Not found");
                }
                //return entity.Employees.FirstOrDefault(e => e.ID == id);
            }
        }

        public HttpResponseMessage Post([FromBody]Employee employee)
        {
            try
            {
                using (DemoEntities entity = new DemoEntities())
                {
                    entity.Employees.Add(employee);
                    entity.SaveChanges();
                    var message = Request.CreateResponse(HttpStatusCode.Created, employee);
                    message.Headers.Location = new Uri(Request.RequestUri + employee.ID.ToString());
                    return message;

                }

            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex);

                //throw;
            }
            
        }

         
     

         
    }
}
