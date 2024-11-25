using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TrilhaApiDesafio.Context;
using TrilhaApiDesafio.Models;

namespace TrilhaApiDesafio.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TarefaController : ControllerBase
    {
        private readonly OrganizadorContext _context;

        public TarefaController(OrganizadorContext context)
        {
            _context = context;
        }

        [HttpGet("{id}")]
        public IActionResult ObterPorId(int id)
        {
            var tarefa = _context.Tarefas.Find(id);

            if (tarefa == null)
            {
                return NotFound();
            }
            return Ok(tarefa);
        }

        [HttpGet("ObterTodos")]
        public IActionResult ObterTodos()
        {
            try
            {
                var listaTarefa = _context.Tarefas.ToList();
                return Ok(listaTarefa);
            }
            catch (System.Exception ex)
            {

                return BadRequest(new { Erro = $"Não foi possivel buscar as tarefas no banco: {ex}" });
            }
        }

        [HttpGet("ObterPorTitulo")]
        public IActionResult ObterPorTitulo(string titulo)
        {
          
            try
            {
                var listaTarefas = _context.Tarefas.Where(t => t.Titulo.Contains(titulo)).ToList();
                return Ok(listaTarefas);
            }
            catch (System.Exception ex)
            {

                return BadRequest(new { Erro = $"Não foi possivel pesquisar no banco: {ex}" });
            }


        }


        [HttpGet("ObterPorData")]
        public IActionResult ObterPorData(DateTime data)
        {
            var tarefa = _context.Tarefas.Where(x => x.Data.Date == data.Date);
            return Ok(tarefa);
        }

        [HttpGet("ObterPorStatus")]
        public IActionResult ObterPorStatus(EnumStatusTarefa status)
        {       
            var tarefa = _context.Tarefas.Where(x => x.Status == status);
            return Ok(tarefa);
        }

        [HttpPost]
        public IActionResult Criar(Tarefa tarefa)
        {
            if (tarefa.Data == DateTime.MinValue)
                return BadRequest(new { Erro = "A data da tarefa não pode ser vazia" });

            try
            {
                if (ModelState.IsValid)
                {
                    _context.Tarefas.Add(tarefa);
                    _context.SaveChanges();
                    return CreatedAtAction(nameof(ObterPorId), new { id = tarefa.Id }, tarefa);
                }
                else
                {
                    return BadRequest(new { Erro = "Dados inválidos" });
                }
            }
            catch (System.Exception)
            {

                return BadRequest(new { Erro = "Erro ao salvar tarefa..." });
            }

        }
        [HttpPost("CriarVariasTarefas")]
        public IActionResult CriarVarias(List<Tarefa> tarefas)
        {
            if (tarefas == null || !tarefas.Any())
                return BadRequest(new { Erro = "A lista de tarefas não pode ser vazia" });
            var optionsBuilder = new DbContextOptionsBuilder<OrganizadorContext>();
            optionsBuilder.LogTo(Console.WriteLine);


            foreach (var tarefa in tarefas)
            {
                if (tarefa.Data == DateTime.MinValue)
                {
                    return BadRequest(new { Erro = $"A tarefa '{tarefa.Titulo}' possui uma data inválida" });
                }

                if (!ModelState.IsValid)
                {
                    return BadRequest(new { Erro = $"Dados inválidos para a tarefa '{tarefa.Titulo}'" });
                }
            }

            try
            {
                _context.Tarefas.AddRange(tarefas);
                _context.SaveChanges();
                return Ok(new { Mensagem = $"{tarefas.Count} tarefas foram adicionadas com sucesso" });
            }
            catch (Exception ex)
            {
                return BadRequest(new { Erro = "Erro ao salvar tarefas", Detalhes = ex.InnerException?.Message ?? ex.Message });
            }

        }

        [HttpPut("{id}")]
        public IActionResult Atualizar(int id, Tarefa tarefa)
        {
            var tarefaBanco = _context.Tarefas.Find(id);

            if (tarefaBanco == null)
                return NotFound();

            if (tarefa.Data == DateTime.MinValue)
                return BadRequest(new { Erro = "A data da tarefa não pode ser vazia" });

            tarefaBanco.Titulo = tarefa.Titulo;
            tarefaBanco.Descricao=tarefa.Descricao;
            tarefaBanco.Status=tarefa.Status;
            tarefaBanco.Data=tarefa.Data;

            _context.Tarefas.Update(tarefaBanco);
            _context.SaveChanges();
            return Ok(tarefaBanco);
        }

        [HttpDelete("{id}")]
        public IActionResult Deletar(int id)
        {
            var tarefaBanco = _context.Tarefas.Find(id);

            if (tarefaBanco == null)
                return NotFound();

            // TODO: Remover a tarefa encontrada através do EF e salvar as mudanças (save changes)
            return NoContent();
        }
    }
}
