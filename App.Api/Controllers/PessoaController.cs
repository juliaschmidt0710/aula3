using App.Domain.Entities;
using App.Domain.Interfaces.Application;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace App.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PessoaController : Controller
    {
        private IPessoaService _service;

        public PessoaController(IPessoaService service)
        {
            _service = service;
        }

        [HttpGet("BuscaPorId")]
        public JsonResult BuscaPorID(Guid id)
        {
            return Json(new { lista = _service.BuscaPorId(id) });
        }

        [HttpGet("ListaPessoas")]
        public JsonResult ListaPessoas(string nome, int pesoMaiorQue, int pesoMenorQue)
        {
            return Json(new {lista = _service.listaPessoas(nome, pesoMaiorQue, pesoMenorQue) });
            
            
        }

 

        [HttpPost("Salvar")]
        public JsonResult Salvar (string nome, int peso, DateTime datanascimento, bool ativo, Guid idCidade )
        {
            var obj = new Pessoa
            {
                Nome = nome,
                DataNascimento = datanascimento,
                Peso = peso,
                Ativo = ativo,
                CidadeId = idCidade
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
