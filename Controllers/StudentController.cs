using Ajax_crud.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Diagnostics;

namespace Ajax_crud.Controllers
{
    public class StudentController : Controller
    {
        private readonly ILogger<StudentController> _logger;
        public static List<StudentModel> students = new List<StudentModel>();

        public StudentController(ILogger<StudentController> logger)
        {
            _logger = logger;
            students = new List<StudentModel>();
            students.Add(new StudentModel()
            {
                Id = 1,
                Email = "najwa@nssit.com.my",
                Name = "Najwa"
            });
            students.Add(new StudentModel()
            {
                Id = 2,
                Email = "syahirah@nssit.com.my",
                Name = "Syahirah"
            });
            students.Add(new StudentModel()
            {
                Id = 3,
                Email = "syamimi@nssit.com.my",
                Name = "Syamimi"
            });
            students.Add(new StudentModel()
            {
                Id = 4,
                Email = "husna@nssit.com.my",
                Name = "Husna"
            });
        }

        public IActionResult Privacy()
        {
            return View();
        }
        public IActionResult Index()
        {
            return View(students);
        }

        [HttpGet]
        public JsonResult GetDetailsById(int id)
        {
            var student = students.Where(d => d.Id.Equals(id)).FirstOrDefault();
            JsonResponseViewModel model = new JsonResponseViewModel();
            if (student != null)
            {
                model.ResponseCode = 0;
                model.ResponseMessage = JsonConvert.SerializeObject(student);
            }
            else
            {
                model.ResponseCode = 1;
                model.ResponseMessage = "No record available";
            }
            return Json(model);
        }

        [HttpPost]
        public JsonResult InsertStudent(IFormCollection formcollection)
        {
            StudentModel student = new StudentModel();
            student.Email = formcollection["email"];
            student.Name = formcollection["name"];
            JsonResponseViewModel model = new JsonResponseViewModel();
            //MAKE DB CALL and handle the response
            if (student != null)
            {
                model.ResponseCode = 0;
                model.ResponseMessage = JsonConvert.SerializeObject(student);
            }
            else
            {
                model.ResponseCode = 1;
                model.ResponseMessage = "No record available";
            }
            return Json(model);
        }

        [HttpPut]
        public JsonResult UpdateStudent(IFormCollection formcollection)
        {
            StudentModel student = new StudentModel();
            student.Id = int.Parse(formcollection["id"]);
            student.Email = formcollection["email"];
            student.Name = formcollection["name"];
            JsonResponseViewModel model = new JsonResponseViewModel();
            //MAKE DB CALL and handle the response
            if (student != null)
            {
                model.ResponseCode = 0;
                model.ResponseMessage = JsonConvert.SerializeObject(student);
            }
            else
            {
                model.ResponseCode = 1;
                model.ResponseMessage = "No record available";
            }
            return Json(model);
        }

        [HttpDelete]
        public JsonResult DeleteStudent(IFormCollection formcollection)
        {
            StudentModel student = new StudentModel();
            student.Id = int.Parse(formcollection["id"]);
            JsonResponseViewModel model = new JsonResponseViewModel();
            //MAKE DB CALL and handle the response
            if (student != null)
            {
                model.ResponseCode = 0;
                model.ResponseMessage = JsonConvert.SerializeObject(student);
            }
            else
            {
                model.ResponseCode = 1;
                model.ResponseMessage = "No record available";
            }
            return Json(model);
        }
    }
}
