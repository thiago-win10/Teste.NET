using CamadaServices.Interfaces;
using Domain.Models;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace XYZ.Controllers
{
    [Authorize]
    [Route("api/clientes")]

    public class ClientesController : Controller
    {
        private readonly IClienteService _clienteService;

        public ClientesController(IClienteService clienteService)
        {
            _clienteService = clienteService;
        }

        [HttpGet("", Name = "Clientes")]
        public async Task<IActionResult> Index()
        {
            var list = await _clienteService.GetClientesAsync();
            return Ok(list);
        }

        [HttpGet("{id}", Name = "Cliente")]
        public async Task<IActionResult> Obter(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var empresa = await _clienteService.FindByIdAsync(id.Value);
            if (empresa == null)
            {
                return NotFound();
            }

            return Ok(empresa);
        }
        
        [Route("")]
        [HttpPost]
        public async Task<IActionResult> Cadastrar([FromBody] Cliente cliente)
        {
            if (cliente == null)
                return BadRequest();

            if (!ModelState.IsValid)
                return UnprocessableEntity(ModelState);

            await _clienteService.InsertAsync(cliente);
            return Ok();

        }

        [HttpPut("{id}", Name = "AtualizarCliente")]
        public ActionResult Atualizar(int id, [FromBody] Cliente cliente)
        {
            var obj = _clienteService.FindByIdAsync(id);
            if (obj == null)
                return NotFound("Dados nao Encontrado.");

            if (cliente == null)
                return BadRequest();

            _clienteService.UpdateAsync(cliente);
            return Ok(cliente);
        }

        [HttpDelete("{id}", Name = "ExcluirCliente")]

        public ActionResult Deletar(int id)
        {
            var obj = _clienteService.FindByIdAsync(id);
            if (obj == null)
                return NotFound("Dados nao Encontrado.");

            _clienteService.DeleteAsync(id);

            return NoContent();
        }

    }
}
        