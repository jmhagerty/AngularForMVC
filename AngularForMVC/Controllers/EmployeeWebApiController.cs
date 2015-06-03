using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

using AngularForMVC.Models;

namespace AngularForMVC.Controllers
{
    public class EmployeeWebApiController : ApiController
    {
        // GET: api/EmployeeWebApi
        public IEnumerable<EmployeeVM> Get(int id=0)
        {
			List<EmployeeVM> list = new List<EmployeeVM>()
			{
				new EmployeeVM(){
					FullName = "Milton Waddams"
				},
				new EmployeeVM(){
					FullName="Andy Bernard"
				}
			};

			// Default return type will be JSON in camelCase (Global.asax.cs)
			return list;
			//return new string[] { "value1", "value2" };
        }

        // GET: api/EmployeeWebApi/5
		//public string Get(int id)
		//{
		//	return "value";
		//}

        // POST: api/EmployeeWebApi
        public HttpResponseMessage Post([FromBody]EmployeeVM employee)
        {
			//var response = new HttpResponseMessage(HttpStatusCode.OK);
			//response.Content = new StringContent("12345");
			//return response;

			return Request.CreateResponse<string>(HttpStatusCode.OK, "12345");

        }

        // PUT: api/EmployeeWebApi/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/EmployeeWebApi/5
        public void Delete(int id)
        {
        }
    }
}
