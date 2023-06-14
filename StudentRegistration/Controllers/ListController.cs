using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NuGet.Protocol.Core.Types;
using StudentRegistration.Interface;
using StudentRegistration.Models;
using StudentRegistration.ViewModel;

namespace StudentRegistration.Controllers
{
    public class ListController : Controller
    {
        private readonly IStudent _Repository;
        private readonly DatabaseContext _Context;
        private readonly IMapper _mepper;

        public ListController(IStudent repository, IMapper mepper, DatabaseContext context)
        {
            _Repository = repository;
            _mepper = mepper;
            _Context = context;
        }

        public IActionResult Index()
        {
            var country = _Context.tblCountries.ToList();
            var modal = _mepper.Map<List<TblCountryViewModel>>(country);
            return View(modal);
        }
        public IActionResult CreateCountry()
        {
            TblCountryViewModel viewModel = new TblCountryViewModel();
            return PartialView("_Create", viewModel);
        }
        [HttpPost]
        public IActionResult CreateCountry(TblCountry tbl)
        {
            _Context.tblCountries.Add(tbl);
            _Context.SaveChanges();
            return RedirectToAction("Index");
        }
        public IActionResult EditCountry(int id)
        {
            var data = _Context.tblCountries.Where(x => x.CId == id).FirstOrDefault();
            TblCountryViewModel viewModel = new TblCountryViewModel();

            if (data != null)
            {
                viewModel.CId = data.CId;
                viewModel.CName = data.CName;
                return PartialView("_Create", viewModel);
            }
            return View(data);
        }
        [HttpPost]
        public IActionResult EditCountry(TblCountry tbl)
        {
            _Context.tblCountries.Update(tbl);
            _Context.SaveChanges();
            return RedirectToAction("Index");
        }
        public IActionResult Delete(int id)
        {
            var data = _Context.tblCountries.Where(x => x.CId == id).FirstOrDefault();
            _Context.tblCountries.Remove(data);
            _Context.SaveChanges();
            return RedirectToAction("Index");

        }
        // ------------------TblState------------------------------------------------------------
        public IActionResult Index1()
        {
            StudentViewModel abc = new StudentViewModel();
            var data = _Repository.GetAll();
            abc.ListStudents = _mepper.Map<List<StudentViewModel>>(data);
            var country = _Context.tblCountries.ToList();
            abc.tblCountries = _mepper.Map<List<TblCountryViewModel>>(country);
            var state = _Context.tblStates.ToList();
            abc.tblStates = _mepper.Map<List<TblStateViewModel>>(state);
            return View(abc);
        }
        public IActionResult CreateState()
        {
            TblStateViewModel viewModel = new TblStateViewModel();
            return PartialView("_CreateState", viewModel);
        }
        [HttpPost]
        public IActionResult CreateState(TblState tblState)
        {
            _Context.tblStates.Add(tblState);
            _Context.SaveChanges();
            return RedirectToAction("Index1");
        }
        public IActionResult EditState(int id)
        {
            var data = _Context.tblStates.Where(x => x.SId == id).FirstOrDefault();
            TblStateViewModel viewModel = new TblStateViewModel();

            if (data != null)
            {
                viewModel.SId = data.SId;
                viewModel.SName = data.SName;
                viewModel.CId = data.CId;
               
            }
            return PartialView("_CreateState", viewModel);
            //return View(data);
        }
        [HttpPost]
        public IActionResult EditState(TblState tblState)
        {
            _Context.tblStates.Update(tblState);
            _Context.SaveChanges();
            return RedirectToAction("Index1");
        }
        public IActionResult Delete1(int id)
        {
            var data = _Context.tblStates.Where(x => x.SId == id).FirstOrDefault();
            _Context.tblStates.Remove(data);
            _Context.SaveChanges();
            return RedirectToAction("Index1");
        }

        //------------------------TblCity---------------------------------
        public IActionResult Index2()
        {
            StudentViewModel abc = new StudentViewModel();
            var data = _Repository.GetAll();
            abc.ListStudents = _mepper.Map<List<StudentViewModel>>(data);
            var country = _Context.tblCountries.ToList();
            abc.tblCountries = _mepper.Map<List<TblCountryViewModel>>(country);
            var state = _Context.tblStates.ToList();
            abc.tblStates = _mepper.Map<List<TblStateViewModel>>(state);
            var city = _Context.tblCities.ToList();
            abc.tblCities = _mepper.Map<List<TblCityViewModel>>(city);
            return View(abc);
        }
        public IActionResult CreateCity()
        {
            TblCityViewModel viewModel = new TblCityViewModel();
            return PartialView("_CreateCity", viewModel);
        }
        [HttpPost]
        public IActionResult CreateCity(TblCity tblCity)
        {
            _Context.tblCities.Add(tblCity);
            _Context.SaveChanges();
            return RedirectToAction("Index2");
        }
        public IActionResult EditCity(int id)
        {
            var data = _Context.tblCities.Where(x => x.DId == id).FirstOrDefault();
            TblCityViewModel viewModel = new TblCityViewModel();

            if (data != null)
            {
                var countryid = _Context.tblStates.Where(x => x.SId == data.SId).Select(x => x.CId).FirstOrDefault();
                viewModel.DId = data.DId;
                viewModel.DName = data.DName;
                viewModel.SId = data.SId;
                viewModel.CId = countryid;

            }
            return PartialView("_CreateCity", viewModel);
            //return View(data);
        }
        [HttpPost]
        public IActionResult EditCity(TblCity tblCity)
        {
            _Context.tblCities.Update(tblCity);
            _Context.SaveChanges();
            return RedirectToAction("Index2");
        }
        public IActionResult Deletee(int id)
        {
            var data = _Context.tblCities.Where(x => x.DId == id).FirstOrDefault();
            _Context.tblCities.Remove(data);
            _Context.SaveChanges();
            return RedirectToAction("Index2");
        }
    }
}
