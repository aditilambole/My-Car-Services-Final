using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using MyCarServicesFinal;
using MyCarServicesFinal.Models;
using MyCarServicesFinal.ViewModel;

namespace MyCarServicesFinal.Controllers
{
    public class HomeController : Controller
    {
        ApplicationDbContext _context;

        public HomeController()
        {
            _context = new ApplicationDbContext();

        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }
        //Index page------------------------------------------------------------------------------
        public ActionResult Index()
        {
            return View();
        }
        //Add Customer Form------------------------------------------------------------------------
        public ActionResult AddCustomerForm()
        {
            return View();
        }
        //Add customer method----------------------------------------------------------------------with validations------------
        public ActionResult AddCustomer(ApplicationUser customer)
        {
            if (!ModelState.IsValid)
            {
                //    var viewModel = new CustomerCarViewModel
                //    {
                //        Customers = customer
                //    };
                return View("AddCustomerForm", customer);
            }
            else
            {
                _context.Users.Add(customer);
                _context.SaveChanges();
                return RedirectToAction("About", "Home");
            }


        }
        public ActionResult About()
        {
            ViewBag.Message = "List of Customers";
            // GET: Customer--------------------------------------------------------------------------------------------
            var customers = _context.Users.ToList();
            return View(customers);

        }
        //delete--------------------------------------------------------------------------------------------------
        public ActionResult DeleteCustomer(ApplicationUser customer)//model binding
        {
            var cust = _context.Users.Find(customer.Id);

            _context.Users.Remove(cust);
            _context.SaveChanges();
            return RedirectToAction("About", "Home");
        }
        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        //Onclick - ShowCar------------------------------------------------------------------------------------
        public ActionResult ViewCars(ApplicationUser customer)
        {
            var users = _context.Users.SingleOrDefault(c => c.Id == customer.Id);
            var viewmodel = new CustomerCarViewModel
            {
                User = users,
                Cars = _context.Cars.ToList()
            };
            return View(viewmodel);
        }
        [Authorize]
        public ActionResult ViewCarsUser(ApplicationUser customer)
        {
            var userId = User.Identity.GetUserId();
            var users = _context.Users.SingleOrDefault(c => c.Id == userId);
            var viewmodel = new CustomerCarViewModel
            {
                User = users,
                Cars = _context.Cars.ToList()
            };
            return View("ViewCars", viewmodel);
        }

        public ActionResult AddNewCar(SingleCustomerCarViewModel viewModel)
        {
            try
            {
                viewModel.GetCar.UserId = viewModel.User.Id;
                var customer = _context.Users.Find(viewModel.User.Id);
                // var car = viewModel.GetCar;
                _context.Cars.Add(viewModel.GetCar);
                _context.SaveChanges();
                return RedirectToAction("ViewCars", "Home", viewModel.User);
            }

            catch
            {
                return View("AddNewCarForm", viewModel);
            }

            //var viewModel1 = new SingleCustomerCarViewModel
            //{

            //};



        }

        //form new car----------------------------------------------------------------------------------------
        public ActionResult AddNewCarForm(ApplicationUser customer)
        {
            SingleCustomerCarViewModel viewModel = new SingleCustomerCarViewModel
            {
                User = customer
            };
            return View(viewModel);
        }
        //DeleteCar-------------------------------------------------------------------------------------------
        public ActionResult DeleteCar(Car car)
        {
            var customer = _context.Users.Find(car.UserId);
            var cars = _context.Cars.Find(car.Id);
            _context.Cars.Remove(cars);
            _context.SaveChanges();
            return RedirectToAction("ViewCars", "Home", customer);

        }
        public ActionResult EditCustomerForm(ApplicationUser customer)
        {//edit cust view--------------------------------------------------------------------------------------
            return View(customer);
        }
        public ActionResult EditCustomer(ApplicationUser customer)
        {
            if (!ModelState.IsValid)
            {
                return View("EditCustomerForm", customer);
            }
            else
            {
                var customerInDb = _context.Users.Find(customer.Id);

                customerInDb.FirstName = customer.FirstName;
                customerInDb.LastName = customer.LastName;
                customerInDb.Email = customer.Email;
                customerInDb.PhoneNumber = customer.PhoneNumber;
                //customerInDb.Address = customer.Address;
                customerInDb.City = customer.City;
                //customerInDb.PostalCode = customer.PostalCode;


                _context.SaveChanges();

                return RedirectToAction("About", customer);
            }

        }
        //EDIT CAR FORM-------------------------------------------------------------------------------------
        public ActionResult EditCarForm(Car car)
        {
            return View(car);
        }
        //Edit Car------------------------------------------------------------------------------------------
        public ActionResult EditCar(Car car)
        {
            if (!ModelState.IsValid)
            {
                return View("EditCarForm", car);
            }
            else
            {
                var customer = _context.Users.Find(car.UserId);
                var carInDb = _context.Cars.Find(car.Id);
                carInDb.VIN = car.VIN;
                carInDb.Model = car.Model;
                carInDb.Style = car.Style;
                carInDb.Company = car.Company;
                carInDb.Color = car.Color;

                _context.SaveChanges();
                return RedirectToAction("ViewCars", "Home", customer);
            }
        }
        //View Services-----------------------------------------------------------------------------------
        public ActionResult ViewServices(Car car)
        {
            var viewmodel = new ServiceViewModel
            {
                Car = car,
                Services = _context.Services.ToList(),
                ServiceType = _context.ServiceTypes.ToList()
            };
            return View(viewmodel);
        }
        //view services ----------------------------------------------------------------------------------
        public ActionResult AddService(ServiceViewModel serviceViewModel)
        {
            if (!ModelState.IsValid)
            {
                serviceViewModel.Car = _context.Cars.Find(serviceViewModel.Car.Id);
                serviceViewModel.ServiceType = _context.ServiceTypes.ToList();
                serviceViewModel.Services = _context.Services.ToList();
                return View("ViewServices", serviceViewModel);

            }
            else
            {
                serviceViewModel.Service.CarId = serviceViewModel.Car.Id;
                serviceViewModel.Service.DateAdded = DateTime.Today;
                var car = _context.Cars.Find(serviceViewModel.Car.Id);
                _context.Services.Add(serviceViewModel.Service);
                _context.SaveChanges();
                return RedirectToAction("ViewServices", "Home", car);
            }
        }
        //delete service--------------------------------------------------------------------------------------
        public ActionResult DeleteService(Service service)
        {
            var car = _context.Cars.Find(service.CarId);
            var myService = _context.Services.Find(service.Id);

            _context.Services.Remove(myService);
            _context.SaveChanges();

            return RedirectToAction("ViewServices", car);
        }
        //show More Services
        // GET: Service
        public ActionResult ShowMore(Car car)
        {
            var viewmodel = new ServiceViewModel
            {
                Car = car,
                Services = _context.Services.ToList(),
                ServiceType = _context.ServiceTypes.ToList()
            };
            return View(viewmodel);
        }
        public ActionResult Search(string search = "", string option = "")
        {
            if (search.Equals(""))
            {
                var customers = _context.Users.ToList();
                return View("About", customers);
            }
            else
            {
                if (option.Equals("Email"))
                {
                    var customers = _context.Users.Where(c => c.Email.Equals(search)).ToList();
                    var viewModel = new CustAndCustViewModel
                    {
                        Users = customers
                    };
                    return View("About", viewModel.Users);
                }

                else if (option.Equals("Mobile"))
                {
                    var searchMobile = Convert.ToInt64(search);
                    var customers = _context.Users.Where(c => c.PhoneNumber.Equals(searchMobile)).ToList();
                    var viewModel = new CustAndCustViewModel
                    {
                        Users = customers
                    };
                    return View("About", viewModel.Users);
                }

                else
                {
                    var customers = _context.Users.Where(c => c.FirstName.Equals(search)).ToList();
                    var viewModel = new CustAndCustViewModel
                    {
                        Users = customers
                    };
                    return View("About", viewModel.Users);
                }
            }
        }
    }

}