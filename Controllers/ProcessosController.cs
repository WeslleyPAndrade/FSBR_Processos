using FSBR_Processos.Domain.Interfaces;
using FSBR_Processos.Models.Context;
using FSBR_Processos.Models.DTOs;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace FSBR_Processos.Controllers
{
    public class ProcessosController : Controller
    {
        private readonly ProcessoDbContext _context;
        private readonly IProcessosDomain _processosDomain;

        public ProcessosController(ProcessoDbContext context, IProcessosDomain processosDomain)
        {
            _context = context;
            _processosDomain = processosDomain;
        }

        [HttpGet]
        public async Task<IActionResult> Index(int page = 1, int pageSize = 10)
        {
            ProcessoInputDTO input = new(page, pageSize);
            var output = _processosDomain.ObterTodosProcessos(input).Result;

            ViewBag.CurrentPage = output.Page;
            ViewBag.TotalPages = output.TotalPages;

            return View(output.Processos);
        }

        [HttpGet]
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return BadRequest();
            }

            var processo = await _processosDomain.ObterProcessoPorId(id.Value);

            if (processo == null)
            {
                return NotFound();
            }

            return View(processo);
        }


        [HttpGet]
        public IActionResult Create()
        {
            var listaUfs = _processosDomain.RecuperarUFs().Result;
            ViewBag.UFs = new SelectList(listaUfs, "Sigla", "Sigla");

            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("NomeProcesso,NPU,UF,Municipio")] CriarProcessoInputDTO processo)
        {
            if (ModelState.IsValid)
            {
                await _processosDomain.CriarProcesso(processo);
                return RedirectToAction(nameof(Index));
            }
            return View(processo);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var processo = await _processosDomain.EditarProcesso(id.Value);
            if (processo == null)
            {
                return NotFound();
            }

            var listaUfs = _processosDomain.RecuperarUFs().Result;
            var listaMunicipios = _processosDomain.GetMunicipiosByUF(processo.UF).Result;

            ViewBag.UFs = new SelectList(listaUfs, "Sigla", "Sigla");
            ViewBag.Municipios = new SelectList(listaMunicipios, "Nome", "Nome");

            return View(processo);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,NomeProcesso,NPU,UF,Municipio")] EditarProcessoInputDTO processo)
        {
            if (id != processo.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {

                await _processosDomain.SalvarEditacaoProcesso(processo);

                return RedirectToAction(nameof(Index));
            }

            return View(processo);
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var processo = await _processosDomain.ObterProcessoPorId(id.Value);
            if (processo == null)
            {
                return NotFound();
            }

            return View(processo);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _processosDomain.DeletarProcesso(id);
            return RedirectToAction(nameof(Index));
        }

        public async Task<JsonResult> GetMunicipiosByUF(string uf)
        {
            var municipios = await _processosDomain.GetMunicipiosByUF(uf);
            return Json(municipios.Select(m => new { m.Id, m.Nome }));
        }


        [HttpGet]
        public async Task<IActionResult> ConfirmarVisualizacao(int id)
        {
            await _processosDomain.ConfirmarVisualizacaoAsync(id);
            return RedirectToAction("Details", new { id = id });

        }
    }
}
