using Microsoft.AspNetCore.Mvc;
using SistemaEstoque.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SistemaEstoque.Controllers
{
    public class EstoqueController : Controller
    {
        private ContextEstoque _context { get; set; }
        public EstoqueController(ContextEstoque context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View(_context.Estoques.ToList());
        }

        [HttpPost]
        public async Task<JsonResult> Salvar(string txtNome)
        {
            try
            {
                EstoqueModel estoque = new EstoqueModel();
                estoque.Nome = txtNome;
                _context.Estoques.Add(estoque);
                await _context.SaveChangesAsync();
                return Json(new { success = true });
            }
            catch (Exception ex)
            {
                return Json(new { success = false, message = ex.Message });
            }
        }

        [HttpGet]
        public IActionResult AtualizarProduto(int? id) 
        {
            var modelo = _context.Estoques.Find(id);

            return View(modelo);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult AtualizarProduto(EstoqueModel modelo) 
        {
            if (ModelState.IsValid) 
            {
                _context.Update(modelo);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View(modelo);
        }


        [HttpPost]
        public async Task<IActionResult> Excluir(int id)
        {
            var produto = _context.Estoques.FirstOrDefault(e => e.Id == id);
            _context.Estoques.Remove(produto);
            await _context.SaveChangesAsync();
            return Json(new { success = true });
        }

        public JsonResult Edit(int id)
        {
            var data = _context.Estoques.Where(e => e.Id == id).SingleOrDefault();

            return Json(data);

        }
    }
}
