using CamadaServices.Interfaces;
using Domain.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace XYZ.Controllers
{
    [Authorize]
    [Route("api/produtos")]

    public class ProdutosController : Controller
    {
        private readonly IProdutoService _produtoService;
        public ProdutosController(IProdutoService produtoService)
        {
            _produtoService = produtoService;
        }

        [HttpGet("", Name = "Produtos")]
        public async Task<IActionResult> Index()
        {
            var list = await _produtoService.GetProdutosAsync();
            return Ok(list);
        }

        [HttpGet("{id}", Name = "Produto")]
        public async Task<IActionResult> Obter(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var produto = await _produtoService.FindByIdAsync(id.Value);
            if (produto == null)
            {
                return NotFound();
            }

            return Ok(produto);
        }

        
        [Route("")]
        [HttpPost]
        public async Task<IActionResult> Cadastrar([FromBody] Produto produto)
        {
            if (produto == null)
                return BadRequest();

            if (!ModelState.IsValid)
                return UnprocessableEntity(ModelState);

            await _produtoService.InsertAsync(produto);
            return Ok();

        }

        [HttpPut("{id}", Name = "AtualizarProduto")]
        public ActionResult Atualizar(int id, [FromBody] Produto produto)
        {
            var obj = _produtoService.FindByIdAsync(id);
            if (obj == null)
                return NotFound("Dados nao Encontrado.");

            if (produto == null)
                return BadRequest();

            _produtoService.UpdateAsync(produto);
            return Ok(produto);
        }

        [HttpDelete("{id}", Name = "ExcluirProduto")]

        public ActionResult Deletar(int id)
        {
            var obj = _produtoService.FindByIdAsync(id);
            if (obj == null)
                return NotFound("Dados nao Encontrado.");

            _produtoService.DeleteAsync(id);

            return NoContent();
        }

    }
}

