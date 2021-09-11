using App.Domain.Entities;
using App.Domain.Interfaces.Application;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace App.Api.Controllers
{
    public class CidadeController : Controller
    {
        private ICidadeService _service;

        public CidadeController(ICidadeService service)
        {
            _service = service;
        }
        [HttpGet("BuscaPorId")]
        public JsonResult BuscaPorID(Guid id)
        {
            return Json(new { lista = _service.BuscaPorId(id) });
        }

        [HttpGet("ListaCidades")]
        public JsonResult ListaCidades()
        {
            return Json(new { lista = _service.listaCidades() });
        }

        [HttpPost("Salvar")]
        public JsonResult Salvar(string nome, string cep, string uf)
        {
            var obj = new Cidade
            {
                Nome = nome,
                Cep = cep,
                Uf = uf
            };
            _service.Salvar(obj);
            return Json(true);
        }
        [HttpPost("Remover")]
        public JsonResult Remover(Guid id)
        {
            _service.Remover(id);
            return Json("Deletado");
        }
    }
}
