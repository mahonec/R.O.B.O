using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Talents.Models;
using Talents.Util;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Razor;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Talents.Controllers
{
    public class HomeController : Controller
    {
        [HttpGet, ActionName("Index")]
        public IActionResult Index()
        {
            using (TalentsContext db = new TalentsContext())
            {
                var query = from p in db.People
                            select p;
                try
                {
                    List<People> result = query.ToList();

                    foreach (People people in result)
                    {
                        var queryCity = from c in db.City
                                        where c.CityId == people.CityId
                                        select c;
                        List<City> citys = queryCity.ToList();
                        if (citys.Count > 0)
                            people.City = citys[0];
                    }
                    return View(result);
                }
                catch (Exception ex)
                {
                    return View(ex);
                }
            }
        }

        [HttpGet]
        public IActionResult Insert()
        {
            People people = new People();
            getPeopleCountrys(people);
            getPeopleProvinces(people);
            getPeopleCitys(people);
            ViewBag.People = people;
            return View(people);
        }

        [HttpPost]
        public IActionResult Insert(People obj)
        {
            using (TalentsContext db = new TalentsContext())
            {
                db.People.Add(obj);
                db.SaveChanges();
                return RedirectToAction("Update2", new { id = obj.PeopleId });
            }
        }

        [HttpGet]
        public IActionResult Update(int id)
        {
            using (TalentsContext db = new TalentsContext())
            {
                People obj = db.People.Where(c => c.PeopleId ==
                   id).SingleOrDefault();
                getPeopleCountrys(obj);
                getPeopleProvinces(obj);
                getPeopleCitys(obj);

                ViewBag.People = obj;
                return View(obj);
            }
        }

        [HttpPost, ActionName("Update")]
        public IActionResult Update(People obj)
        {
            using (TalentsContext db = new TalentsContext())
            {
                try
                {
                    obj.ScheduleAvaiableAnswersCheckedString = string.Join(",", obj.ScheduleAvaiableAnswersChecked);
                    obj.BestScheduleAnswersCheckedString = string.Join(",", obj.BestScheduleAnswersChecked);

                    db.Entry(obj).State = EntityState.Modified;
                    db.SaveChanges();
                    return RedirectToAction("Update2", new { id = obj.PeopleId });
                }
                catch (Exception ex)
                {
                    ViewBag.ErrorMessage = ex.Message + " " + ex.InnerException;
                    return View(obj);
                }
            }
        }

        [HttpGet]
        public IActionResult Update2(int? id)
        {
            using (TalentsContext db = new TalentsContext())
            {
                People obj = db.People.Where(c => c.PeopleId ==
                   id).SingleOrDefault();
                ViewBag.People = obj;
                return View(obj);

            }
        }

        [HttpPost, ActionName("Update2")]
        public IActionResult Update2(People obj)
        {
            using (TalentsContext db = new TalentsContext())
            {
                try
                {
                    db.Entry(obj).State = EntityState.Modified;
                    db.SaveChanges();
                    return RedirectToAction("Update3", new { id = obj.PeopleId });
                }
                catch (Exception ex)
                {
                    ViewBag.ErrorMessage = ex.Message + " " + ex.InnerException;
                    return View(obj);
                }
            }
        }

        [HttpGet]
        public IActionResult Update3(int? id)
        {
            using (TalentsContext db = new TalentsContext())
            {
                People obj = db.People.Where(c => c.PeopleId ==
                   id).SingleOrDefault();
                ViewBag.People = obj;
                return View(obj);

            }
        }

        [HttpPost, ActionName("Update3")]
        public IActionResult Update3(People obj)
        {
            using (TalentsContext db = new TalentsContext())
            {
                try
                {
                    db.Entry(obj).State = EntityState.Modified;
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
                catch (Exception ex)
                {
                    ViewBag.ErrorMessage = ex.Message + " " + ex.InnerException;
                    return View(obj);
                }
            }
        }

        public IActionResult Delete(string id)
        {
            using (TalentsContext db = new TalentsContext())
            {
                People obj = db.People.Where(c => c.PeopleId.ToString() ==
               id).SingleOrDefault();
                db.People.Remove(obj);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Error()
        {
            return View();
        }

        public JsonResult GetProvinces(int CountryID)
        {
            using (TalentsContext db = new TalentsContext())
            {
                List<Province> provincelist = new List<Province>();
                provincelist = (from province in db.Province
                                where province.CountryId == CountryID
                                select province).ToList();
                provincelist.Insert(0, new Province { ProvinceId = 0, Name = "Select" });
                return Json(new SelectList(provincelist, "ProvinceId", "Name"));
            }
        }

        public JsonResult GetCitys(int ProvinceID)
        {
            using (TalentsContext db = new TalentsContext())
            {
                List<City> cityList = new List<City>();

                // ------- Getting Data from Database Using EntityFrameworkCore -------
                cityList = (from city in db.City
                            where city.ProvinceId == ProvinceID
                            select city).ToList();

                // ------- Inserting Select Item in List -------
                cityList.Insert(0, new City { CityId = 0, Name = "Select" });

                return Json(new SelectList(cityList, "CityId", "Name"));
            }
        }

        public void getPeopleCountrys(People people)
        {
            using (TalentsContext db = new TalentsContext())
            {
                var queryCountry = from c in db.Country
                                   select c;

                List<Country> countrys = queryCountry.ToList();

                List<SelectListItem> listCountry = new List<SelectListItem>();
                listCountry.Add(new SelectListItem() { Value = "0", Text = "Select" });
                foreach (Country country in countrys)
                    listCountry.Add(new SelectListItem() { Text = country.Name, Value = country.CountryId.ToString(), Selected = country.CountryId == people.CountryId });

                ViewBag.ListofCountry = listCountry;
            }
        }

        public void getPeopleProvinces(People people)
        {
            using (TalentsContext db = new TalentsContext())
            {
                IQueryable<Province> queryProvince = null;
                if (people.CountryId > 0)
                    queryProvince = from p in db.Province
                                    where p.CountryId == people.CountryId
                                    select p;
                else
                    queryProvince = from p in db.Province
                                    select p;

                List<Province> provinces = queryProvince.ToList();

                List<SelectListItem> listProvinces = new List<SelectListItem>();
                listProvinces.Add(new SelectListItem() { Value = "0", Text = "Select" });
                foreach (Province province in provinces)
                    listProvinces.Add(new SelectListItem() { Text = province.Name, Value = province.ProvinceId.ToString(), Selected = province.ProvinceId == people.ProvinceId });

                ViewBag.ListofProvince = listProvinces;
            }
        }

        public void getPeopleCitys(People people)
        {
            using (TalentsContext db = new TalentsContext())
            {
                IQueryable<City> queryCity = null;
                if (people.ProvinceId > 0)
                    queryCity = from c in db.City
                                where c.ProvinceId == people.ProvinceId
                                select c;
                else
                    queryCity = from c in db.City
                                select c;


                List<City> citys = queryCity.ToList();

                List<SelectListItem> listCitys = new List<SelectListItem>();
                listCitys.Add(new SelectListItem() { Value = "0", Text = "Select" });
                foreach (City city in citys)
                    listCitys.Add(new SelectListItem() { Text = city.Name, Value = city.CityId.ToString(), Selected = city.CityId == people.CityId });

                ViewBag.ListofCity = listCitys;
            }
        }
    }
}
