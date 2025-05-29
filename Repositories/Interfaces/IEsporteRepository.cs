using GerenciamentoEsportivoAPI.Models;
using System.Collections.Generic;

namespace GerenciamentoEsportivoAPI.Repositories.Interfaces
{
    public interface IEsporteRepository
    {
        List<Esporte> GetAll();
        Esporte? GetById(int id);
        void Add(Esporte esporte);
        void Update(Esporte esporte);
        void Delete(int id);
    }
}
