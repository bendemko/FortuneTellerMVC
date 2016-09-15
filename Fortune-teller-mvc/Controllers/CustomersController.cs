using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Fortune_teller_mvc.Models;

namespace Fortune_teller_mvc.Controllers
{
    public class CustomersController : Controller
    {
        private FortuneTellerMVCEntities1 db = new FortuneTellerMVCEntities1();

        // GET: Customers
        public ActionResult Index()
        {
            return View(db.Customers.ToList());
        }

        // GET: Customers/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Customer customer = db.Customers.Find(id);
            if (customer == null)
            {
                return HttpNotFound();
            }

            //Even

            if (customer.Age % 2 == 0)
            {
             ViewBag.NumberOfYears = 20;
            }

            //Odd
            else
            {
            ViewBag.NumberOfYears = 35;
            }


            //This determines the user's bank account

            //This find's the letter at a particular position in the user's birth month.
            char c0 = customer.BirthMonth[0];
            char c1 = customer.BirthMonth[1];
            char c2 = customer.BirthMonth[2];

            //This searches the user's first name and determines whether the (0,1st,2nd,3rd...etc) 
            //letter in their birth month is found in their first or last name. 
            int firstNameResult0 = customer.FirstName.IndexOf(c0);
            int lastNameResult0 = customer.LastName.IndexOf(c0);
            int firstNameResult1 = customer.FirstName.IndexOf(c1);
            int lastNameResult1 = customer.LastName.IndexOf(c1);
            int firstNameResult2 = customer.FirstName.IndexOf(c2);
            int lastNameResult2 = customer.LastName.IndexOf(c2);


            //This adds up the result
            int finalResult0 = (firstNameResult0 + lastNameResult0);
            int finalResult1 = (firstNameResult1 + lastNameResult1);
            int finalResult2 = (firstNameResult2 + lastNameResult2);

            

            if (finalResult0 >= -1)
            {
                ViewBag.Money = 40000;
            }

            else if (finalResult1 >= -1)
            {
                ViewBag.Money = 100000;
            }

            else if (finalResult2 >= -1)
            {
                ViewBag.Money = 1000000;
            }

            else
            {
                ViewBag.Money = 0;
            }


            //This determines where the user will live
            if (customer.NumberOfSiblings == "0")
                ViewBag.NumberOfSiblings = "Belize";
            else if (customer.NumberOfSiblings == "1")
                ViewBag.NumberOfSiblings = "Outer Siberia";
            if (customer.NumberOfSiblings == "2")
                ViewBag.NumberOfSiblings = "North Korea";
            else if (customer.NumberOfSiblings == "3")
                ViewBag.NumberOfSiblings = "Costa Rica";
            else
                ViewBag.NumberOfSiblings = "Italy";

            //This determines the user's mode of transport
            if (customer.FavoriteColor.ToUpper() == "RED")
                ViewBag.FavoriteColor = "Ferrari";
            else if (customer.FavoriteColor.ToUpper() == "ORANGE")
                ViewBag.FavoriteColor = "sailboat";
            else if (customer.FavoriteColor.ToUpper() == "YELLOW")
                ViewBag.FavoriteColor = "pickup truck";
            else if (customer.FavoriteColor.ToUpper() == "GREEN")
                ViewBag.FavoriteColor = "rusted bicycle";
            else if (customer.FavoriteColor.ToUpper() == "BLUE")
                ViewBag.FavoriteColor = "Buick";
            else if (customer.FavoriteColor.ToUpper() == "INDIGO")
                ViewBag.FavoriteColor = "VW bus";
            else if (customer.FavoriteColor.ToUpper() == "VIOLET")
                ViewBag.FavoriteColor = "crap station wagon";

            return View(customer);
        }

        // GET: Customers/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Customers/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "CustomerID,FirstName,LastName,Age,BirthMonth,FavoriteColor,NumberOfSiblings")] Customer customer)
        {
            if (ModelState.IsValid)
            {
                db.Customers.Add(customer);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(customer);
        }

        // GET: Customers/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Customer customer = db.Customers.Find(id);
            if (customer == null)
            {
                return HttpNotFound();
            }
            return View(customer);
        }

        // POST: Customers/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "CustomerID,FirstName,LastName,Age,BirthMonth,FavoriteColor,NumberOfSiblings")] Customer customer)
        {
            if (ModelState.IsValid)
            {
                db.Entry(customer).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(customer);
        }

        // GET: Customers/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Customer customer = db.Customers.Find(id);
            if (customer == null)
            {
                return HttpNotFound();
            }
            return View(customer);
        }

        // POST: Customers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Customer customer = db.Customers.Find(id);
            db.Customers.Remove(customer);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
