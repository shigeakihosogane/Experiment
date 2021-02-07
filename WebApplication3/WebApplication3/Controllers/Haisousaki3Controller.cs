using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebApplication3.Models;

namespace WebApplication3.Controllers
{
    public class Haisousaki3Controller : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Haisousaki3
        public async Task<ActionResult> Index()
        {
            var haisousaki3s = db.Haisousaki3s.Include(h => h.Zyuusyoroku);
            return View(await haisousaki3s.ToListAsync());
        }

        // GET: Haisousaki3/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Haisousaki3 haisousaki3 = await db.Haisousaki3s.FindAsync(id);
            if (haisousaki3 == null)
            {
                return HttpNotFound();
            }
            return View(haisousaki3);
        }

        // GET: Haisousaki3/Create
        public ActionResult Create()
        {
            ViewBag.ZyuusyorokuId = new SelectList(db.Zyuusyorokus, "Id", "MeisyouRyaku");
            return View();
        }

        // POST: Haisousaki3/Create
        // 過多ポスティング攻撃を防止するには、バインド先とする特定のプロパティを有効にしてください。
        // 詳細については、https://go.microsoft.com/fwlink/?LinkId=317598 をご覧ください。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Id,UserId,ZyuusyorokuId,EriaId")] Haisousaki3 haisousaki3)
        {
            if (ModelState.IsValid)
            {
                db.Haisousaki3s.Add(haisousaki3);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.ZyuusyorokuId = new SelectList(db.Zyuusyorokus, "Id", "MeisyouRyaku", haisousaki3.ZyuusyorokuId);
            return View(haisousaki3);
        }

        // GET: Haisousaki3/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Haisousaki3 haisousaki3 = await db.Haisousaki3s.FindAsync(id);
            if (haisousaki3 == null)
            {
                return HttpNotFound();
            }
            ViewBag.ZyuusyorokuId = new SelectList(db.Zyuusyorokus, "Id", "MeisyouRyaku", haisousaki3.ZyuusyorokuId);
            return View(haisousaki3);
        }

        // POST: Haisousaki3/Edit/5
        // 過多ポスティング攻撃を防止するには、バインド先とする特定のプロパティを有効にしてください。
        // 詳細については、https://go.microsoft.com/fwlink/?LinkId=317598 をご覧ください。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Id,UserId,ZyuusyorokuId,EriaId")] Haisousaki3 haisousaki3)
        {
            if (ModelState.IsValid)
            {
                db.Entry(haisousaki3).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.ZyuusyorokuId = new SelectList(db.Zyuusyorokus, "Id", "MeisyouRyaku", haisousaki3.ZyuusyorokuId);
            return View(haisousaki3);
        }

        // GET: Haisousaki3/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Haisousaki3 haisousaki3 = await db.Haisousaki3s.FindAsync(id);
            if (haisousaki3 == null)
            {
                return HttpNotFound();
            }
            return View(haisousaki3);
        }

        // POST: Haisousaki3/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Haisousaki3 haisousaki3 = await db.Haisousaki3s.FindAsync(id);
            db.Haisousaki3s.Remove(haisousaki3);
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
