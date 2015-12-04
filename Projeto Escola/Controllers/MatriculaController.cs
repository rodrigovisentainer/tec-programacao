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
    public class MatriculaController : Controller
    {
        private EscolaContext db = new EscolaContext();

        // GET: Matriculas
        public ActionResult Index(string Aluno)
        {
            List<Aluno> alunos = db.Alunos.ToList();
            ViewBag.Aluno = new SelectList(alunos, "AlunoID", "Nome");
            List<Matricula> matriculas = null;
            if (Aluno != null)
            {
                int alunoId = Int32.Parse(Aluno);
                matriculas = db.Matriculas.Include(m => m.Aluno).Include(m => m.MateriaLecionada).Where(m => m.Aluno.AlunoID == alunoId).ToList();
            }
            else
            {
                matriculas = db.Matriculas.Include(m => m.Aluno).Include(m => m.MateriaLecionada).ToList();
            }
            return View(matriculas);
        }

        // GET: Matriculas/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Matricula matricula = db.Matriculas.Find(id);
            if (matricula == null)
            {
                return HttpNotFound();
            }
            return View(matricula);
        }

        // GET: Matriculas/Create
        public ActionResult Create()
        {
            ViewBag.AlunoID = new SelectList(db.Alunos, "AlunoID", "Nome");
            ViewBag.MateriaLecionadaID = new SelectList(db.MateriaLecionadas, "MateriaLecionadaID", "MateriaID");
            return View();
        }

        // POST: Matriculas/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MatriculaID,AlunoID,MateriaLecionadaID,Nota")] Matricula matricula)
        {
            if (ModelState.IsValid)
            {
                db.Matriculas.Add(matricula);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.AlunoID = new SelectList(db.Alunos, "AlunoID", "Nome", matricula.AlunoID);
            ViewBag.MateriaLecionadaID = new SelectList(db.MateriaLecionadas, "MateriaLecionadaID", "MateriaID", matricula.MateriaLecionadaID);
            return View(matricula);
        }

        // GET: Matriculas/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Matricula matricula = db.Matriculas.Find(id);
            if (matricula == null)
            {
                return HttpNotFound();
            }
            ViewBag.AlunoID = new SelectList(db.Alunos, "AlunoID", "Nome", matricula.AlunoID);
            ViewBag.MateriaLecionadaID = new SelectList(db.MateriaLecionadas, "MateriaLecionadaID", "MateriaID", matricula.MateriaLecionadaID);
            return View(matricula);
        }

        // POST: Matriculas/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MatriculaID,AlunoID,MateriaLecionadaID,Nota")] Matricula matricula)
        {
            if (ModelState.IsValid)
            {
                db.Entry(matricula).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.AlunoID = new SelectList(db.Alunos, "AlunoID", "Nome", matricula.AlunoID);
            ViewBag.MateriaLecionadaID = new SelectList(db.MateriaLecionadas, "MateriaLecionadaID", "MateriaID", matricula.MateriaLecionadaID);
            return View(matricula);
        }

        // GET: Matriculas/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Matricula matricula = db.Matriculas.Find(id);
            if (matricula == null)
            {
                return HttpNotFound();
            }
            return View(matricula);
        }

        // POST: Matriculas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Matricula matricula = db.Matriculas.Find(id);
            db.Matriculas.Remove(matricula);
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
