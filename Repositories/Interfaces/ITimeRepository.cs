using GerenciamentoEsportivoAPI.Models;
using System.Collections.Generic;

namespace GerenciamentoEsportivoAPI.Repositories.Interfaces
{
    public interface ITimeRepository
    {
        List<Time> GetAll();
        Time? GetById(int id);
        void Add(Time time);
        void Update(Time time);
        void Delete(int id);
    }
}
