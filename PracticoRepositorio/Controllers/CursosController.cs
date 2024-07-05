using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PracticoRepositorio.Models;
using PracticoRepositorio.Repositorio;

namespace PracticoRepositorio.Controllers
{
    public class CursosController : Controller
    {
        //private readonly PruebaEntityContext _context;

        //public CursosController(PruebaEntityContext context)
        //{
        //    _context = context;
        //}

        //// GET: Cursos
        //public async Task<IActionResult> Index()
        //{
        //    return View(await _context.Cursos.ToListAsync());
        //}

        //// GET: Cursos/Details/5
        //public async Task<IActionResult> Details(int? id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }

        //    var curso = await _context.Cursos
        //        .FirstOrDefaultAsync(m => m.Id == id);
        //    if (curso == null)
        //    {
        //        return NotFound();
        //    }

        //    return View(curso);
        //}

        //// GET: Cursos/Create
        //public IActionResult Create()
        //{
        //    return View();
        //}

        //// POST: Cursos/Create
        //// To protect from overposting attacks, enable the specific properties you want to bind to.
        //// For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> Create([Bind("Id,NombreCurso")] Curso curso)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        _context.Add(curso);
        //        await _context.SaveChangesAsync();
        //        return RedirectToAction(nameof(Index));
        //    }
        //    return View(curso);
        //}

        //// GET: Cursos/Edit/5
        //public async Task<IActionResult> Edit(int? id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }

        //    var curso = await _context.Cursos.FindAsync(id);
        //    if (curso == null)
        //    {
        //        return NotFound();
        //    }
        //    return View(curso);
        //}

        //// POST: Cursos/Edit/5
        //// To protect from overposting attacks, enable the specific properties you want to bind to.
        //// For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> Edit(int id, [Bind("Id,NombreCurso")] Curso curso)
        //{
        //    if (id != curso.Id)
        //    {
        //        return NotFound();
        //    }

        //    if (ModelState.IsValid)
        //    {
        //        try
        //        {
        //            _context.Update(curso);
        //            await _context.SaveChangesAsync();
        //        }
        //        catch (DbUpdateConcurrencyException)
        //        {
        //            if (!CursoExists(curso.Id))
        //            {
        //                return NotFound();
        //            }
        //            else
        //            {
        //                throw;
        //            }
        //        }
        //        return RedirectToAction(nameof(Index));
        //    }
        //    return View(curso);
        //}

        //// GET: Cursos/Delete/5
        //public async Task<IActionResult> Delete(int? id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }

        //    var curso = await _context.Cursos
        //        .FirstOrDefaultAsync(m => m.Id == id);
        //    if (curso == null)
        //    {
        //        return NotFound();
        //    }

        //    return View(curso);
        //}

        //// POST: Cursos/Delete/5
        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> DeleteConfirmed(int id)
        //{
        //    var curso = await _context.Cursos.FindAsync(id);
        //    if (curso != null)
        //    {
        //        _context.Cursos.Remove(curso);
        //    }

        //    await _context.SaveChangesAsync();
        //    return RedirectToAction(nameof(Index));
        //}

        //private bool CursoExists(int id)
        //{
        //    return _context.Cursos.Any(e => e.Id == id);
        //}

        private readonly IUnitOfWork _unitOfWork;

        public CursosController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        // GET: Cursos
        public async Task<IActionResult> Index()
        {
            return View(await Task.FromResult(_unitOfWork.Cursos.GetAll()));
        }

        // GET: Cursos/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var curso = await Task.FromResult(_unitOfWork.Cursos.GetById(id.Value));
            if (curso == null)
            {
                return NotFound();
            }

            return View(curso);
        }

        // GET: Cursos/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Cursos/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,NombreCurso")] Curso curso)
        {
            if (ModelState.IsValid)
            {
                _unitOfWork.Cursos.Insert(curso);
                _unitOfWork.Save();
                return RedirectToAction(nameof(Index));
            }
            return View(curso);
        }

        // GET: Cursos/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var curso = await Task.FromResult(_unitOfWork.Cursos.GetById(id.Value));
            if (curso == null)
            {
                return NotFound();
            }
            return View(curso);
        }

        // POST: Cursos/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,NombreCurso")] Curso curso)
        {
            if (id != curso.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _unitOfWork.Cursos.Update(curso);
                    _unitOfWork.Save();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CursoExists(curso.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(curso);
        }

        // GET: Cursos/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var curso = await Task.FromResult(_unitOfWork.Cursos.GetById(id.Value));
            if (curso == null)
            {
                return NotFound();
            }

            return View(curso);
        }

        // POST: Cursos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var curso = await Task.FromResult(_unitOfWork.Cursos.GetById(id));
            if (curso != null)
            {
                _unitOfWork.Cursos.Delete(id);
                _unitOfWork.Save();
            }
            return RedirectToAction(nameof(Index));
        }

        private bool CursoExists(int id)
        {
            return _unitOfWork.Cursos.GetAll().Any(e => e.Id == id);
        }
    }
}
