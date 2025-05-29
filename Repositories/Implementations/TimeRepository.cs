using GerenciamentoEsportivoAPI.Models;
using GerenciamentoEsportivoAPI.Repositories.Interfaces;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace GerenciamentoEsportivoAPI.Repositories.Implementations
{
    public class TimeRepository : ITimeRepository
    {
        private readonly string _filePath = "Data/times.txt";
        private List<Time> times;
        private int nextId;

        public TimeRepository()
        {
            var directory = Path.GetDirectoryName(_filePath);
            if (!string.IsNullOrEmpty(directory) && !Directory.Exists(directory))
            {
                Directory.CreateDirectory(directory);
            }

            if (!File.Exists(_filePath))
                File.WriteAllText(_filePath, string.Empty);

            times = File.ReadAllLines(_filePath)
                        .Where(line => !string.IsNullOrWhiteSpace(line))
                        .Select(ParseFromLine)
                        .ToList();

            nextId = times.Any() ? times.Max(t => t.Id) + 1 : 1;
        }

        public List<Time> GetAll() => times;

        public Time? GetById(int id) => times.FirstOrDefault(t => t.Id == id);

        public void Add(Time time)
        {
            time.Id = nextId++;
            times.Add(time);
            SaveToFile();
        }

        public void Update(Time time)
        {
            var index = times.FindIndex(t => t.Id == time.Id);
            if (index != -1)
            {
                times[index] = time;
                SaveToFile();
            }
        }

        public void Delete(int id)
        {
            var time = GetById(id);
            if (time != null)
            {
                times.Remove(time);
                SaveToFile();
            }
        }

        private void SaveToFile()
        {
            var lines = times.Select(FormatToLine);
            File.WriteAllLines(_filePath, lines);
        }

        private Time ParseFromLine(string line)
        {
            var parts = line.Split(';');

            return new Time
            {
                Id = int.Parse(parts[0]),
                Nome = parts[1],
                AnoFundacao = int.Parse(parts[2]),
                QtdTitulos = int.Parse(parts[3]),
                Titulos = parts.Length > 4 && !string.IsNullOrWhiteSpace(parts[4])
                    ? parts[4].Split(',').ToList()
                    : new List<string>(),
                EsporteId = int.Parse(parts[5])
            };
        }

        private string FormatToLine(Time time)
        {
            string titulos = time.Titulos != null && time.Titulos.Any()
                ? string.Join(",", time.Titulos)
                : "";

            return $"{time.Id};{time.Nome};{time.AnoFundacao};{time.QtdTitulos};{titulos};{time.EsporteId}";
        }
    }
}
