using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using AngularForMVC.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System.Net; // HttpStatusCode

namespace AngularForMVC.Controllers
{
    public class EmployeeController : Controller
    {
        public ActionResult GetEmployees()
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

			return GetJsonContentResult(list);

			//var camelCaseFormatter = new JsonSerializerSettings();
			//camelCaseFormatter.ContractResolver = new CamelCasePropertyNamesContractResolver();
			//var jsonResult = new ContentResult
			//{
			//	Content = JsonConvert.SerializeObject(list, camelCaseFormatter),
			//	ContentType = "application/json"
			//};
			//return jsonResult;

			// return an error
			//return new HttpStatusCodeResult(404, "Our custom error message...");
        }

		// MVC Framework does the job of converting the posted data to 
		// the EmployeeVM fields specified in model class
		//public ActionResult Create(EmployeeVM employee)

		// specifies which item(s) to exclude (strips out Notes field)
		//public ActionResult Create([Bind(Exclude="Notes")]EmployeeVM employee)

		// specifies which item to include
		//public ActionResult Create([Bind(Include="Notes")]EmployeeVM employee)

		// specifies which items to include
		//public ActionResult Create([Bind(Include = "FullName,Notes")]EmployeeVM employee)

		// specifies which embedded object to pass to this method 
		// ( See DataService.js -> insertEmployee() -> data.NewEmployee )
		//public ActionResult Create([Bind(Prefix = "NewEmployee")]EmployeeVM employee)

		public ActionResult Create(EmployeeVM employee)
		{
			if (ModelState.IsValid)
			{
				var id = new { id = 12345 };

				// return an error
				//return new HttpStatusCodeResult(HttpStatusCode.Created, "New employee added");

				// return json
				return GetJsonContentResult(id);
			}

			List<string> errors = new List<string>();
			errors.Add("Insert Failed");
			if (!ModelState.IsValidField("Notes"))
			{
				errors.Add("Notes must be at least 5 characters long");
			}

			return new HttpStatusCodeResult(HttpStatusCode.InternalServerError, String.Join("  ", errors));
		}

		public ActionResult Update(EmployeeVM employee)
		{
			if (ModelState.IsValid)
			{
				return new HttpStatusCodeResult(HttpStatusCode.OK, "Update success");

				// return an error
				//return new HttpStatusCodeResult(HttpStatusCode.Created, "New employee added");

				// return json
				//return GetJsonContentResult(employee);
			}

			List<string> errors = new List<string>();
			errors.Add("Update Failed");
			if (!ModelState.IsValidField("Notes"))
			{
				errors.Add("Notes must be at least 5 characters long");
			}

			return new HttpStatusCodeResult(HttpStatusCode.InternalServerError, String.Join("  ", errors));
		}

		// Converts data to be returned to the client to camelCase
		public ContentResult GetJsonContentResult(object data)
		{
			var camelCaseFormatter = new JsonSerializerSettings();
			camelCaseFormatter.ContractResolver = new CamelCasePropertyNamesContractResolver();
			var jsonResult = new ContentResult
			{
				Content = JsonConvert.SerializeObject(data, camelCaseFormatter),
				ContentType = "application/json"
			};

			return jsonResult;
		}
    }
}