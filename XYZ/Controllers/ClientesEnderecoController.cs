using CamadaServices.Interfaces;
using Domain.Models;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace XYZ.Controllers
{
    [Route("api/clientesendereco")]
    public class ClientesEnderecoController : Controller
    {
        private readonly IClienteEnderecoService _enderecoService;
        public ClientesEnderecoController(IClienteEnderecoService enderecoService)
        {
            _enderecoService = enderecoService;
        }

        [HttpGet("", Name = "ClientesEndereco")]
        public async Task<IActionResult> Index()
        {
            var list = await _enderecoService.GetClientesEnderecoAsync(); 
            return Ok(list);
        }

        [HttpGet("{id}", Name = "Endereco")]
        public async Task<IActionResult> Obter(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var endereco = await _enderecoService.FindByIdAsync(id.Value);
            if (endereco == null)
            {
                return NotFound();
            }

            return Ok(endereco);
        }

        [Route("")]
        [HttpPost]
        public async Task<IActionResult> Cadastrar([FromBody] ClienteEndereco endereco)
        {
            if (endereco == null)
                return BadRequest();

            if (!ModelState.IsValid)
                return UnprocessableEntity(ModelState);

            await _enderecoService.InsertAsync(endereco);
            return Ok();

        }

        [HttpPut("{id}", Name = "AtualizarEndereco")]
        public ActionResult Atualizar(int id, [FromBody] ClienteEndereco endereco)
        {
            var obj = _enderecoService.FindByIdAsync(id);
            if (obj == null)
                return NotFound("Dados nao Encontrado.");

            if (endereco == null)
                return BadRequest();

            _enderecoService.UpdateAsync(endereco);
            return Ok(endereco);
        }


        [HttpDelete("{id}", Name = "ExcluirEndereco")]

        public ActionResult Deletar(int id)
        {
            var obj = _enderecoService.FindByIdAsync(id);
            if (obj == null)
                return NotFound("Dados nao Encontrado.");

            _enderecoService.DeleteAsync(id);

            return NoContent();
        }

    }
}   

