using GerenciamentoEsportivoAPI.Models;
using GerenciamentoEsportivoAPI.Repositories.Interfaces;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace GerenciamentoEsportivoAPI.Repositories.Implementations
{
    public class EsporteRepository : IEsporteRepository
    {
        private readonly string _filePath = "Data/esportes.txt";
        private List<Esporte> esportes;
        private int nextId;

        public EsporteRepository()
        {
            var directory = Path.GetDirectoryName(_filePath);
            if (!string.IsNullOrEmpty(directory) && !Directory.Exists(directory))
                Directory.CreateDirectory(directory);

            if (!File.Exists(_filePath))
                File.WriteAllText(_filePath, string.Empty);

            esportes = File.ReadAllLines(_filePath)
                        .Where(line => !string.IsNullOrWhiteSpace(line))
                        .Select(ParseFromLine)
                        .ToList();

            nextId = esportes.Any() ? esportes.Max(e => e.Id) + 1 : 1;
        }


        public List<Esporte> GetAll() => esportes;

        public Esporte? GetById(int id) => esportes.FirstOrDefault(e => e.Id == id);

        public void Add(Esporte esporte)
        {
            esporte.Id = nextId++;
            esportes.Add(esporte);
            SaveToFile();
        }

        public void Update(Esporte esporte)
        {
            var index = esportes.FindIndex(e => e.Id == esporte.Id);
            if (index != -1)
            {
                esportes[index] = esporte;
                SaveToFile();
            }
        }

        public void Delete(int id)
        {
            var esporte = GetById(id);
            if (esporte != null)
            {
                esportes.Remove(esporte);
                SaveToFile();
            }
        }

        private void SaveToFile()
        {
            var lines = esportes.Select(FormatToLine);
            File.WriteAllLines(_filePath, lines);
        }

        private Esporte ParseFromLine(string line)
        {
            var parts = line.Split(';');
            return new Esporte
            {
                Id = int.Parse(parts[0]),
                Nome = parts[1]
            };
        }

        private string FormatToLine(Esporte esporte)
        {
            return $"{esporte.Id};{esporte.Nome}";
        }
    }
}
