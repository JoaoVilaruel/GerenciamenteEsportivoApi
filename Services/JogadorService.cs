using GerenciamentoEsportivoAPI.Models;
using GerenciamentoEsportivoAPI.Repositories.Interfaces;
using System.Collections.Generic;

namespace GerenciamentoEsportivoAPI.Services
{
    public class JogadorService
    {
        private readonly IJogadorRepository _jogadorRepository;

        public JogadorService(IJogadorRepository jogadorRepository)
        {
            _jogadorRepository = jogadorRepository;
        }

        public List<Jogador> GetAll() => _jogadorRepository.GetAll();

        public Jogador? GetById(int id) => _jogadorRepository.GetById(id);

        public void Add(Jogador jogador) => _jogadorRepository.Add(jogador);

        public void Update(Jogador jogador) => _jogadorRepository.Update(jogador);

        public void Delete(int id) => _jogadorRepository.Delete(id);
    }
}
