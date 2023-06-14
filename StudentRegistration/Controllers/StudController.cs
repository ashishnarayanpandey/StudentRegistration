using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NuGet.Protocol.Core.Types;
using StudentRegistration.Interface;
using StudentRegistration.Models;
using StudentRegistration.ViewModel;

namespace StudentRegistration.Controllers
{
    public class StudController : Controller
    {
        private readonly IStudent _Repository;
        private readonly DatabaseContext _Context;
        private readonly IMapper _mepper;
       
        public StudController(IStudent repository, IMapper mepper, DatabaseContext context)
        {
            _Repository = repository;
            _mepper = mepper;
            _Context = context;
        }

        public IActionResult Index()
        {
            StudentViewModel abc = new StudentViewModel();
            var data = _Repository.GetAll();
            abc.ListStudents = _mepper.Map<List<StudentViewModel>>(data);
            var country = _Context.tblCountries.ToList();
            abc.tblCountries = _mepper.Map<List<TblCountryViewModel>>(country);
            var state = _Context.tblStates.ToList();
            abc.tblStates= _mepper.Map<List<TblStateViewModel>>(state);
            var city = _Context.tblCities.ToList();
            abc.tblCities = _mepper.Map<List<TblCityViewModel>>(city);
            return View(abc);
        }
        //public IActionResult Index()
        //{
        //    StudentViewModel viewModel = new StudentViewModel();
        //    viewModel.ListStudents = (List<Student>)_Repository.GetAll();
        //    viewModel.tblCountries = _Context.tblCountries.ToList();
        //    viewModel.tblStates = _Context.tblStates.ToList();
        //    viewModel.tblCities = _Context.tblCities.ToList();
        //    return View(viewModel);
            
        //}
        [HttpGet]
        public IActionResult Create()
        {
            StudentViewModel viewModel= new StudentViewModel();
            return PartialView("_Create",viewModel);
        }
        
        [HttpPost]
        public IActionResult Create(Student student, IFormFile file)
        {
            string pth = Path.Combine("wwwroot/PICS");
            string FN = Guid.NewGuid().ToString() + "-" + file.FileName;
            string filepath = Path.Combine(pth, FN);
            using (FileStream fs = System.IO.File.Create(filepath))
            {
                file.CopyTo(fs);
                fs.Flush();
            }
           
            student.Student_Image = FN;
            _Repository.Insert(student);
            _Repository.saved();
            return RedirectToAction("Index");
        }

        public JsonResult GetCountry()
        {
            var cnt = _Context.tblCountries.ToList();
            return new JsonResult(cnt);

        }

        public JsonResult GetState(int id)
        {
            var ct = _Context.tblStates.Where(x => x.CId == id).ToList();
            return new JsonResult(ct);

        }

        public JsonResult GetCity(int id)
        {
            var ct = _Context.tblCities.Where(x => x.SId == id).ToList();
            return new JsonResult(ct);
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
           
            var data = _Repository.GetById(id);
            StudentViewModel viewModel = new StudentViewModel();

            if (data != null)
            {
                viewModel.Student_Name = data.Student_Name;
                viewModel.School_Name = data.School_Name;
                viewModel.Standard_Class = data.Standard_Class;
                viewModel.Student_Image = data.Student_Image;
                viewModel.MobileNo=data.MobileNo;
                viewModel.Address = data.Address;
                TempData["ddd"] = data.Student_Image;
                viewModel.Student_Id = data.Student_Id;
                viewModel.CId = data.CId;
                viewModel.SId = data.SId;
                viewModel.DId = data.DId;

                return PartialView("_Create", viewModel);
            }
            return View(data);
            
        }
        [HttpPost]
        public IActionResult Edit(Student student, IFormFile file)
        {
            var data = _Repository.GetById(student.Student_Id);
            string filename = "";
            string pth = Path.Combine("wwwroot/PICS");

            if (file == null)
            {
                filename = data.Student_Image;
            }
            else
            {

                filename = Guid.NewGuid().ToString() + "-" + file.FileName;
                string filepath = Path.Combine(pth, filename);
                using (FileStream fs = System.IO.File.Create(filepath))
                {
                    file.CopyTo(fs);
                    fs.Flush();
                }

                string ppp = TempData["ddd"].ToString();
                string old = Path.Combine("wwwroot/PICS", ppp);
                if (System.IO.File.Exists(old))
                {
                    System.IO.File.Delete(old);
                }
                student.Student_Image = filename;
            }

            data.Student_Name = student.Student_Name;
            data.School_Name = student.School_Name;
            data.Standard_Class = student.Standard_Class;
            //data.Student_Image = student.Student_Image;
            data.MobileNo = student.MobileNo;
            data.Address = student.Address;
            data.DId = student.DId;
            data.CId = student.CId;
            data.SId = student.SId;
            //data.Student_Id = student.Student_Id;
            data.Student_Image = filename;

            _Repository.Update(data);
            _Repository.saved();
            return RedirectToAction("Index");
        }

        public IActionResult Delete(int id)
        {

            var data = _Repository.GetById(id);
            string filepath = Path.Combine("wwwroot/PICS", data.Student_Image);
            if (System.IO.File.Exists(filepath))
            {
                System.IO.File.Delete(filepath);
            }
           
            _Repository.Delete(data);
            _Repository.saved();
            return RedirectToAction("Index");

        }
    }
}
