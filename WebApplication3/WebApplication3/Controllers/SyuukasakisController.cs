using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace WebApplication3.Models
{
    public class SyuukasakisController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Syuukasakis
        public async Task<ActionResult> Index()
        {
            return View(await db.Syuukasakis.ToListAsync());
        }

        // GET: Syuukasakis/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Syuukasaki syuukasaki = await db.Syuukasakis.FindAsync(id);
            if (syuukasaki == null)
            {
                return HttpNotFound();
            }
            return View(syuukasaki);
        }

        // GET: Syuukasakis/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Syuukasakis/Create
        // 過多ポスティング攻撃を防止するには、バインド先とする特定のプロパティを有効にしてください。
        // 詳細については、https://go.microsoft.com/fwlink/?LinkId=317598 をご覧ください。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Id,UserId,ZyuusyorokuId,EriaId")] Syuukasaki syuukasaki)
        {
            if (ModelState.IsValid)
            {
                db.Syuukasakis.Add(syuukasaki);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(syuukasaki);
        }

        // GET: Syuukasakis/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Syuukasaki syuukasaki = await db.Syuukasakis.FindAsync(id);
            if (syuukasaki == null)
            {
                return HttpNotFound();
            }
            return View(syuukasaki);
        }

        // POST: Syuukasakis/Edit/5
        // 過多ポスティング攻撃を防止するには、バインド先とする特定のプロパティを有効にしてください。
        // 詳細については、https://go.microsoft.com/fwlink/?LinkId=317598 をご覧ください。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Id,UserId,ZyuusyorokuId,EriaId")] Syuukasaki syuukasaki)
        {
            if (ModelState.IsValid)
            {
                db.Entry(syuukasaki).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(syuukasaki);
        }

        // GET: Syuukasakis/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Syuukasaki syuukasaki = await db.Syuukasakis.FindAsync(id);
            if (syuukasaki == null)
            {
                return HttpNotFound();
            }
            return View(syuukasaki);
        }

        // POST: Syuukasakis/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Syuukasaki syuukasaki = await db.Syuukasakis.FindAsync(id);
            db.Syuukasakis.Remove(syuukasaki);
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
