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
    public class ZyuusyorokusController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Zyuusyorokus
        public async Task<ActionResult> Index()
        {
            return View(await db.Zyuusyorokus.ToListAsync());
        }

        // GET: Zyuusyorokus/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Zyuusyoroku zyuusyoroku = await db.Zyuusyorokus.FindAsync(id);
            if (zyuusyoroku == null)
            {
                return HttpNotFound();
            }
            return View(zyuusyoroku);
        }

        // GET: Zyuusyorokus/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Zyuusyorokus/Create
        // 過多ポスティング攻撃を防止するには、バインド先とする特定のプロパティを有効にしてください。
        // 詳細については、https://go.microsoft.com/fwlink/?LinkId=317598 をご覧ください。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Id,ZyuusyorokuId,MeisyouRyaku,MeisyouSei,Zyuusyo1,Zyuusyo2,Zyuusyo3,Zyuusyo4,DennwaBanngou,FaxBanngou,EriaId")] Zyuusyoroku zyuusyoroku)
        {
            if (ModelState.IsValid)
            {
                db.Zyuusyorokus.Add(zyuusyoroku);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(zyuusyoroku);
        }

        // GET: Zyuusyorokus/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Zyuusyoroku zyuusyoroku = await db.Zyuusyorokus.FindAsync(id);
            if (zyuusyoroku == null)
            {
                return HttpNotFound();
            }
            return View(zyuusyoroku);
        }

        // POST: Zyuusyorokus/Edit/5
        // 過多ポスティング攻撃を防止するには、バインド先とする特定のプロパティを有効にしてください。
        // 詳細については、https://go.microsoft.com/fwlink/?LinkId=317598 をご覧ください。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Id,ZyuusyorokuId,MeisyouRyaku,MeisyouSei,Zyuusyo1,Zyuusyo2,Zyuusyo3,Zyuusyo4,DennwaBanngou,FaxBanngou,EriaId")] Zyuusyoroku zyuusyoroku)
        {
            if (ModelState.IsValid)
            {
                db.Entry(zyuusyoroku).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(zyuusyoroku);
        }

        // GET: Zyuusyorokus/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Zyuusyoroku zyuusyoroku = await db.Zyuusyorokus.FindAsync(id);
            if (zyuusyoroku == null)
            {
                return HttpNotFound();
            }
            return View(zyuusyoroku);
        }

        // POST: Zyuusyorokus/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Zyuusyoroku zyuusyoroku = await db.Zyuusyorokus.FindAsync(id);
            db.Zyuusyorokus.Remove(zyuusyoroku);
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
