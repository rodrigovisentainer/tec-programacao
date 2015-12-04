using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Escola.Models;

namespace Escola.Controllers
{
    public class MateriaLecionadasController : Controller
    {
        private EscolaContext db = new EscolaContext();

        // GET: MateriaLecionadas
        public ActionResult Index()
        {
            var materiaLecionadas = db.MateriaLecionadas.Include(m => m.Professor);
            return View(materiaLecionadas.ToList());
        }

        // GET: MateriaLecionadas/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MateriaLecionada materiaLecionada = db.MateriaLecionadas.Find(id);
            if (materiaLecionada == null)
            {
                return HttpNotFound();
            }
            return View(materiaLecionada);
        }

        // GET: MateriaLecionadas/Create
        public ActionResult Create()
        {
            ViewBag.ProfessorID = new SelectList(db.Professores, "ProfessorID", "Nome");
            return View();
        }

        // POST: MateriaLecionadas/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MateriaLecionadaID,Ano,Semestre,MateriaID,ProfessorID")] MateriaLecionada materiaLecionada)
        {
            if (ModelState.IsValid)
            {
                db.MateriaLecionadas.Add(materiaLecionada);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ProfessorID = new SelectList(db.Professores, "ProfessorID", "Nome", materiaLecionada.ProfessorID);
            return View(materiaLecionada);
        }

        // GET: MateriaLecionadas/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MateriaLecionada materiaLecionada = db.MateriaLecionadas.Find(id);
            if (materiaLecionada == null)
            {
                return HttpNotFound();
            }
            ViewBag.ProfessorID = new SelectList(db.Professores, "ProfessorID", "Nome", materiaLecionada.ProfessorID);
            return View(materiaLecionada);
        }

        // POST: MateriaLecionadas/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MateriaLecionadaID,Ano,Semestre,MateriaID,ProfessorID")] MateriaLecionada materiaLecionada)
        {
            if (ModelState.IsValid)
            {
                db.Entry(materiaLecionada).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ProfessorID = new SelectList(db.Professores, "ProfessorID", "Nome", materiaLecionada.ProfessorID);
            return View(materiaLecionada);
        }

        // GET: MateriaLecionadas/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MateriaLecionada materiaLecionada = db.MateriaLecionadas.Find(id);
            if (materiaLecionada == null)
            {
                return HttpNotFound();
            }
            return View(materiaLecionada);
        }

        // POST: MateriaLecionadas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            MateriaLecionada materiaLecionada = db.MateriaLecionadas.Find(id);
            db.MateriaLecionadas.Remove(materiaLecionada);
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
