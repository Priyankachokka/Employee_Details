using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Employee_Details.Models;

namespace Employee_Details.Controllers
{
    public class HomeController : Controller
    {
        private DBContext db = new DBContext();

        // GET: Home
        public async Task<ActionResult> Index()
        {
            return View(await db.UserInfoes.ToListAsync());
        }

        // GET: Home/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UserInfo userInfo = await db.UserInfoes.FindAsync(id);
            if (userInfo == null)
            {
                return HttpNotFound();
            }
            return View(userInfo);
        }

        // GET: Home/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Home/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "empName,empMobile,empAddress,empDept,empId")] UserInfo userInfo)
        {
            if (ModelState.IsValid)
            {
                db.UserInfoes.Add(userInfo);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(userInfo);
        }

        // GET: Home/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UserInfo userInfo = await db.UserInfoes.FindAsync(id);
            if (userInfo == null)
            {
                return HttpNotFound();
            }
            return View(userInfo);
        }

        // POST: Home/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "empName,empMobile,empAddress,empDept,empId")] UserInfo userInfo)
        {
            if (ModelState.IsValid)
            {
                db.Entry(userInfo).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(userInfo);
        }

        // GET: Home/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UserInfo userInfo = await db.UserInfoes.FindAsync(id);
            if (userInfo == null)
            {
                return HttpNotFound();
            }
            return View(userInfo);
        }

        // POST: Home/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            UserInfo userInfo = await db.UserInfoes.FindAsync(id);
            db.UserInfoes.Remove(userInfo);
            await db.SaveChangesAsync();
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
