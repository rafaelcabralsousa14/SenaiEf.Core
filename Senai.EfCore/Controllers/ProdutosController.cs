using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Senai.EfCore.Domains;
using Senai.EfCore.Interfaces;
using Senai.EfCore.Repositories;

namespace Senai.EfCore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProdutosController : ControllerBase
    {
        private readonly IProdutoRepository _produtoRepository;

        public ProdutosController()
        {
            _produtoRepository = new ProdutoRepository();
        }

        [HttpPost]
        public IActionResult Cadastrar(Produto produto)
        {
            try
            {
                Produto p = new Produto();
                p.Nome = produto.Nome;
                p.Preco = produto.Preco;

                _produtoRepository.Adicionar(p);

                return Ok(new { data = p });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{id}")]
        public IActionResult Alterar(Guid id, Produto produto)
        {
            try
            {
                Produto p = _produtoRepository.BuscarPorId(id);

                if (p == null)
                {
                    return NotFound();
                }

                p.Nome = produto.Nome;
                p.Preco = produto.Preco;

                _produtoRepository.Editar(p);

                return Ok(new { data = p });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public IActionResult Remover(Guid id)
        {
            try
            {
                Produto p = _produtoRepository.BuscarPorId(id);

                if (p == null)
                {
                    return NotFound();
                }

                _produtoRepository.Remover(id);

                return Ok(new { data = p });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        public IActionResult Listar()
        {
            try
            {
                var produtos = _produtoRepository.Listar();

                return Ok(new { data = produtos });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{id}")]
        public IActionResult BuscarPorId(Guid id)
        {
            try
            {
                Produto p = _produtoRepository.BuscarPorId(id);

                if (p == null)
                {
                    return NotFound();
                }

                return Ok(new { data = p });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
}

