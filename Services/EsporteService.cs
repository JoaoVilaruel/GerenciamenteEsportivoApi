using GerenciamentoEsportivoAPI.Models;
using GerenciamentoEsportivoAPI.Repositories.Interfaces;
using System.Collections.Generic;

namespace GerenciamentoEsportivoAPI.Services
{
    public class EsporteService
    {
        private readonly IEsporteRepository _esporteRepository;

        public EsporteService(IEsporteRepository esporteRepository)
        {
            _esporteRepository = esporteRepository;
        }

        public List<Esporte> GetAll() => _esporteRepository.GetAll();

        public Esporte? GetById(int id) => _esporteRepository.GetById(id);

        public void Add(Esporte esporte) => _esporteRepository.Add(esporte);

        public void Update(Esporte esporte) => _esporteRepository.Update(esporte);

        public void Delete(int id) => _esporteRepository.Delete(id);
    }
}
