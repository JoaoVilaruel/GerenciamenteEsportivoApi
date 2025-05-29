using GerenciamentoEsportivoAPI.Models;
using System.Collections.Generic;

namespace GerenciamentoEsportivoAPI.Repositories.Interfaces
{
    public interface IJogadorRepository
    {
        List<Jogador> GetAll();
        Jogador? GetById(int id);
        void Add(Jogador jogador);
        void Update(Jogador jogador);
        void Delete(int id);
    }
}
