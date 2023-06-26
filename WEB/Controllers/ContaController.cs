using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using WEB.Entity;
using WEB.Interface;
using WEB.Models;

namespace WEB.Controllers
{
    [Route("[controller]")]
    public class ContaController : Controller
    {
        private readonly ILogger<ContaController> _logger;
        private readonly IContaService _contaService;

        public ContaController(ILogger<ContaController> logger, IContaService contaService)
        {
            _logger = logger;
            _contaService = contaService;
        }

        public async Task<IActionResult> IndexAsync()
        {
            var todos = await _contaService.ObterTodosAsync();

            ViewData["Notificacao"] = TempData["Notificacao"];

            return View(todos);
        }

        [Route("AdicionarAtualizar/{id}")]
        public async Task<IActionResult> AdicionarAtualizarAsync([FromRoute] int id)
        {
            try
            {
                Conta conta;
                if (id == 0)
                {
                    conta = new Conta();
                }
                else
                {
                    conta = await _contaService.ObterPorIDAsync(id);
                }

                return View(conta);
            }
            catch (HttpRequestException ex)
            {
                TempData["Notificacao"] = ex.Message;
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                TempData["Notificacao"] = ex.Message;
                return RedirectToAction("Index");
            }
        }

        [HttpPost]
        [Route("AdicionarAtualizar")]
        public async Task<IActionResult> AdicionarAtualizarAsync(Conta conta)
        {
            try
            {
                if (conta.ID == 0)
                {
                    await _contaService.AdicionarAsync(conta);
                }
                else
                {
                    await _contaService.AtualizarAsync(conta);
                }

                TempData["Notificacao"] = "Conta salva com sucesso!";
                return RedirectToAction("Index");
            }
            catch (HttpRequestException ex)
            {
                ViewData["Notificacao"] = ex.Message;
                return View(conta);
            }
            catch (Exception ex)
            {
                ViewData["Notificacao"] = ex.Message;
                return View(conta);
            }
        }

        [Route("Excluir/{id}")]
        public async Task<IActionResult> ExcluirAsync([FromRoute] int id)
        {
            try
            {
                await _contaService.ExcluirAsync(id);

                TempData["Notificacao"] = "Conta excluída com sucesso!";
                return RedirectToAction("Index");
            }
            catch (HttpRequestException ex)
            {
                TempData["Notificacao"] = ex.Message;
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                TempData["Notificacao"] = ex.Message;
                return RedirectToAction("Index");
            }
        }
    }
}