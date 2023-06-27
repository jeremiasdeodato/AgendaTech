using AgendasTech.Application.AgendaTech.Interfaces;
using AgendasTech.Application.AgendaTech.Models;
using AgendasTech.Domain.AgendasTech.Entidades;
using AgendasTech.Domain.AgendaTech.Interfaces.Services;
using AgendasTech.Domain.Core.Exceptions;
using AgendasTech.Domain.Core.Interfaces;
using AgendasTech.Infra.Data.AgendaTech;
using AutoMapper;
using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;

namespace AgendasTech.Application.AgendaTech.Services
{
    public class AgendaApplication : IAgendaApplication
    {
        private readonly IMapper _mapper;
        private readonly IAgendaService _agendaService;
        private readonly IUnitOfWork<AgendaTechContext> _unitOfWork;

        public AgendaApplication(IAgendaService agendaService, IUnitOfWork<AgendaTechContext> unitOfWork, IMapper mapper)
        {
            _agendaService = agendaService;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task Inserir(AgendaViewModel viewModel)
        {
            var agenda = new Agenda(viewModel.Nome, viewModel.Email, viewModel.Telefone);

            if (!agenda.EhValido())
            {
                string? mensagem = agenda.MensagemValidacao();
                throw new ErrorValidationException(mensagem ?? "Erro não identificado ao criar a agenda");                
            }

            _agendaService.Inserir(agenda);

            await _unitOfWork.SaveChanges();
        }

        public async Task Atualizar(Guid id, AgendaViewModel viewModel)
        {
            var agenda = await _agendaService.Obter(x => x.Id == id);

            if (agenda == null)
            {
                throw new ErrorValidationException("Agenda não encontrada");
            }
            agenda.AtualizarNome(viewModel.Nome);
            agenda.AtualizarEmail(viewModel.Email);
            agenda.AtualizarTelefone(viewModel.Telefone);

            await _unitOfWork.SaveChanges();
        }

        public async Task<IEnumerable<AgendaListaViewModel>> Obter()
        {
            var agendas = await _agendaService.ObterLista();
            var viewModels = _mapper.Map<IEnumerable<AgendaListaViewModel>>(agendas);

            return viewModels;
        }

        public async Task<AgendaViewModel?> Obter(Guid id)
        {
            var agenda = await _agendaService.Obter(x => x.Id == id);

            var viewModel = _mapper.Map<AgendaViewModel>(agenda);

            if (viewModel == null)
            {
                return null;
            }
            return viewModel;
        }

        public async Task Excluir(Guid id)
        {
            var agenda = await _agendaService.Obter(x => x.Id == id);

            if (agenda is null)
            {
                throw new ValidationException("Não foi possível encontrar a Agenda");
            }

            _agendaService.Excluir(agenda);

            await _unitOfWork.SaveChanges();
        }
    }
}
