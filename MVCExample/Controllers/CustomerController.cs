using MVCExample.DAL;
using MVCExample.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVCExample.ViewModel;
using System.Threading;

namespace MVCExample.Controllers
{
    public class CustomerController : Controller
    {
        //
        // GET: /Customer/

        public ActionResult Index()
        {
            Customer obj = new Customer() { CustomerCode = "ABC12345", CustomerName = "Indi" };
            return View(obj);
        }

        public ActionResult Create()
        {
            CustomerVM obj = new CustomerVM();
            obj.customer = new Customer();
            return View(obj);
        }

        public ActionResult EnterSearch()
        {
            CustomerVM vm = new CustomerVM();
            vm.customers = new List<Customer>();
            return View("Search", vm);
        }

        public ActionResult getCustomers()
        {
            CustomerDAL dal = new CustomerDAL();
            List<Customer> list = dal.Customers.ToList<Customer>();
            return Json(list, JsonRequestBehavior.AllowGet);
        }

        public ActionResult SearchCustomer() 
        {
            CustomerVM vm = new CustomerVM();
            Customer customer = new Customer();
            CustomerDAL dal = new CustomerDAL();
            string str = Request.Form["txtCustomerName"].ToString();

            List<Customer> customers = (from x in dal.Customers
                                        where x.CustomerName == str
                                        select x).ToList<Customer>();

            vm.customer = customer;
            vm.customers = customers;
            return View("Search",vm);
        }

        public ActionResult Submit()
        {
            Customer obj = new Customer();
            if (ModelState.IsValid)
            {
                obj.CustomerName = Request.Form["Customer.CustomerName"];
                obj.CustomerCode = Request.Form["Customer.CustomerCode"];

                CustomerDAL cDal = new CustomerDAL();
                cDal.Customers.Add(obj);
                cDal.SaveChanges();
            }
            return Json(obj, JsonRequestBehavior.AllowGet);
        }
    }
}
