using GerenciamentoEsportivoAPI.Models;
using GerenciamentoEsportivoAPI.Repositories.Interfaces;
using System.Collections.Generic;

namespace GerenciamentoEsportivoAPI.Services
{
    public class TimeService
    {
        private readonly ITimeRepository _timeRepository;

        public TimeService(ITimeRepository timeRepository)
        {
            _timeRepository = timeRepository;
        }

        public List<Time> GetAll() => _timeRepository.GetAll();

        public Time? GetById(int id) => _timeRepository.GetById(id);

        public void Add(Time time) => _timeRepository.Add(time);

        public void Update(Time time) => _timeRepository.Update(time);

        public void Delete(int id) => _timeRepository.Delete(id);
    }
}
