using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using F2018Pranks.Models;

namespace F2018Pranks.Controllers
{
    //Authorization Added
    [Authorize(Roles = "")]
    public class PranksController : Controller
    {
       // private DbModel db = new DbModel();
        private IMockPrank db;

        public PranksController()
        {
            this.db = new EFPrank();
        }

        public PranksController(IMockPrank db)
        {
            this.db = db;
        }

        // GET: Pranks
        public ActionResult Index()
        {
            var pranks = db.Pranks;
            return View("Index", pranks.ToList());
        

        }

        // GET: Pranks/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return View("Error");
                //return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Prank prank = db.Pranks.SingleOrDefault(p => p.PrankId == id);
            if (prank == null)
            {
                return View("Error");

            }
            return View("Details",prank);
        }

        // GET: Pranks/Create
        public ActionResult Create()
        {
            return View("Create");
        }

        // POST: Pranks/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "PrankId,Name,Description,Photo")] Prank prank)
        {
            if (ModelState.IsValid)
            {
                db.Save(prank);
                return RedirectToAction("Index");
            }

            return View("Create", prank);
        }
    }
}
