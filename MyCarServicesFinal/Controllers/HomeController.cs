using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
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
        //Add customer method----------------------------------------------------------------------
        public ActionResult AddCustomer(Customer customer)
        {
            _context.Customers.Add(customer);
            _context.SaveChanges();
            return RedirectToAction("About", "Home");

        }
        public ActionResult About()
        {
            ViewBag.Message = "List of Customers";
        // GET: Customer--------------------------------------------------------------------------------------------
            var customers = _context.Customers.ToList();
            return View(customers);

        }
        //delete--------------------------------------------------------------------------------------------------
        public ActionResult DeleteCustomer(Customer customer)//model binding
        {
            var cust = _context.Customers.Find(customer.Id);

            _context.Customers.Remove(cust);
            _context.SaveChanges();
            return RedirectToAction("About", "Home");
        }
        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        //Onclick - ShowCar------------------------------------------------------------------------------------
        public ActionResult ViewCars(Customer customer)
        {
            var viewmodel = new CustomerCarViewModel
            {
                Customers = customer,
                Cars = _context.Cars.ToList()
            };
            return View(viewmodel);
        }
        public ActionResult AddNewCar(SingleCustomerCarViewModel viewModel)
        {
            viewModel.GetCar.CustomerId = viewModel.GetCustomer.Id;
            var customer = _context.Customers.Find(viewModel.GetCustomer.Id);
            var car = viewModel.GetCar;
            _context.Cars.Add(car);
            _context.SaveChanges();
            return RedirectToAction("ViewCars", "Home", customer);

        }

        //form new car----------------------------------------------------------------------------------------
        public ActionResult AddNewCarForm(Customer customer)
        {
            SingleCustomerCarViewModel viewModel = new SingleCustomerCarViewModel
            {
                GetCustomer = customer
            };
            return View(viewModel);
        }
        //DeleteCar-------------------------------------------------------------------------------------------
        public ActionResult DeleteCar(Car car)
        {
            var customer = _context.Customers.Find(car.CustomerId);
            var cars = _context.Cars.Find(car.Id);
            _context.Cars.Remove(cars);
            _context.SaveChanges();
            return RedirectToAction("ViewCars", "Home", customer);

        }
        public ActionResult EditCustomerForm(Customer customer)
        {//edit cust view--------------------------------------------------------------------------------------
            return View(customer);
        }
        public ActionResult EditCustomer(Customer customer)
        {
            var customerInDb = _context.Customers.Find(customer.Id);

            customerInDb.FirstName = customer.FirstName;
            customerInDb.LastName = customer.LastName;
            customerInDb.Email = customerInDb.Email;
            customerInDb.PhoneNumber = customer.PhoneNumber;
            customerInDb.Address = customer.Address;
            customerInDb.City = customerInDb.City;
            customerInDb.PostalCode = customerInDb.PostalCode;


            _context.SaveChanges();

            return RedirectToAction("About", customer);

        }
        //EDIT CAR FORM-------------------------------------------------------------------------------------
        public ActionResult EditCarForm(Car car)
        {
            return View(car);
        }
        //Edit Car------------------------------------------------------------------------------------------
        public ActionResult EditCar(Car car)
        {
            var customer = _context.Customers.Find(car.CustomerId);
            var carInDb = _context.Cars.Find(car.Id);
            carInDb.VIN = car.VIN;
            carInDb.Model = car.Model;
            carInDb.Style = car.Style;
            carInDb.Company = car.Company;
            carInDb.Color = car.Color;

            _context.SaveChanges();
            return RedirectToAction("ViewCars", "Home", customer);
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
           serviceViewModel.Service.CarId = serviceViewModel.Car.Id;
            serviceViewModel.Service.DateAdded = DateTime.Today;
            var car = _context.Cars.Find(serviceViewModel.Car.Id);
            _context.Services.Add(serviceViewModel.Service);
            _context.SaveChanges();
            return RedirectToAction("ViewServices","Home",car);
            
        }
    }

}