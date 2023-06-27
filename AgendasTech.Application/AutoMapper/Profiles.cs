using AgendasTech.Application.AgendaTech.Models;
using AgendasTech.Domain.AgendasTech.Entidades;
using AutoMapper;

namespace AgendasTech.Application.AutoMapper
{
    public class Profiles : Profile
    {
        public Profiles()
        {
            CreateMap<Agenda, AgendaViewModel>().ReverseMap();
            CreateMap<Agenda, AgendaListaViewModel>().ReverseMap();
        }
    }
}