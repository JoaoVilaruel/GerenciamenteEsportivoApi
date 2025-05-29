using GerenciamentoEsportivoAPI.Models;
using GerenciamentoEsportivoAPI.Repositories.Interfaces;
using System.Globalization;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace GerenciamentoEsportivoAPI.Repositories.Implementations
{
    public class JogadorRepository : IJogadorRepository
    {
        private readonly string _filePath = "Data/jogadores.txt";
        private List<Jogador> jogadores;
        private int nextId;

        public JogadorRepository()
        {
            var directory = Path.GetDirectoryName(_filePath);
            if (!string.IsNullOrEmpty(directory) && !Directory.Exists(directory))
            {
                Directory.CreateDirectory(directory);
            }

            if (!File.Exists(_filePath))
                File.WriteAllText(_filePath, string.Empty);

            jogadores = File.ReadAllLines(_filePath)
                            .Where(line => !string.IsNullOrWhiteSpace(line))
                            .Select(ParseFromLine)
                            .ToList();

            nextId = jogadores.Any() ? jogadores.Max(j => j.Id) + 1 : 1;
        }


        public List<Jogador> GetAll() => jogadores;

        public Jogador? GetById(int id) => jogadores.FirstOrDefault(j => j.Id == id);

        public void Add(Jogador jogador)
        {
            jogador.Id = nextId++;
            jogadores.Add(jogador);
            SaveToFile();
        }

        public void Update(Jogador jogador)
        {
            var index = jogadores.FindIndex(j => j.Id == jogador.Id);
            if (index != -1)
            {
                jogadores[index] = jogador;
                SaveToFile();
            }
        }

        public void Delete(int id)
        {
            var jogador = GetById(id);
            if (jogador != null)
            {
                jogadores.Remove(jogador);
                SaveToFile();
            }
        }

        private void SaveToFile()
        {
            var lines = jogadores.Select(FormatToLine);
            File.WriteAllLines(_filePath, lines);
        }

        private Jogador ParseFromLine(string line)
        {
            var parts = line.Split(';');
            return new Jogador
            {
            Id = int.Parse(parts[0]),
            Nome = parts[1],
            Idade = int.Parse(parts[2]),
            Camisa = int.Parse(parts[3]),
            Salario = double.Parse(parts[4], CultureInfo.InvariantCulture),
            TimeId = int.Parse(parts[5]),
            EsporteId = int.Parse(parts[6])
            };
        }
        private string FormatToLine(Jogador jogador)
        {
            return $"{jogador.Id};{jogador.Nome};{jogador.Idade};{jogador.Camisa};{jogador.Salario.ToString(CultureInfo.InvariantCulture)};{jogador.TimeId};{jogador.EsporteId}";
        }

    }
}
