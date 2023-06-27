using AgendasTech.Application.AgendaTech.Interfaces;
using AgendasTech.Application.AgendaTech.Models;
using Microsoft.AspNetCore.Mvc;

namespace AgendaTech.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AgendaController : AgendaControllerBase<AgendaController>
    {
        private readonly IAgendaApplication _application;

        public AgendaController(IAgendaApplication application)
        {
            _application = application;
        }
                
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var resultado = await _application.Obter();

            return ResponseGet(resultado);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(Guid id)
        {
            var resultado = await _application.Obter(id);

            return ResponseGet(resultado);
        }

        [HttpPost]
        public async Task<IActionResult> Post(AgendaViewModel viewModel)
        {
            await _application.Inserir(viewModel);

            return ResponsePost("Agenda Inserida com sucesso");
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(Guid id, AgendaViewModel viewModel)
        {
            await _application.Atualizar(id, viewModel);

            return ResponsePost("Agenda atualizada com sucesso");
        }
        
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            await _application.Excluir(id);

            return ResponsePost("Comentário excluído com sucesso");
        }
    }
}
