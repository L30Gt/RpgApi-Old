using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using RpgApi.Models;
using RpgApi.Models.Enuns;

namespace RpgApi.Controllers
{
    [ApiController]
    [Route("[Controller]")]
    public class PersonagensExercicioController : ControllerBase
    {
        private static List<Personagem> personagens = new List<Personagem>()
        {
            new Personagem() { Id = 1, Nome = "Frodo", PontosVida = 100, Forca = 17, Defesa = 23, Inteligencia = 33, Classe = ClasseEnum.Cavaleiro },
            new Personagem() { Id = 2, Nome = "Sam", PontosVida = 100, Forca = 15, Defesa = 25, Inteligencia = 30, Classe = ClasseEnum.Cavaleiro },
            new Personagem() { Id = 3, Nome = "Galadriel", PontosVida = 100, Forca = 18, Defesa = 21, Inteligencia = 35, Classe = ClasseEnum.Clerigo },
            new Personagem() { Id = 4, Nome = "Gandalf", PontosVida = 100, Forca = 18, Defesa = 18, Inteligencia = 37, Classe = ClasseEnum.Mago },
            new Personagem() { Id = 5, Nome = "Hobbit", PontosVida = 100, Forca = 20, Defesa = 17, Inteligencia = 31, Classe = ClasseEnum.Cavaleiro },
            new Personagem() { Id = 6, Nome = "Celeborn", PontosVida = 100, Forca = 21, Defesa = 13, Inteligencia = 34, Classe = ClasseEnum.Clerigo },
            new Personagem() { Id = 7, Nome = "Radagast", PontosVida = 100, Forca = 25, Defesa = 11, Inteligencia = 35, Classe = ClasseEnum.Mago }
        };

        [HttpGet("GetAll")]
        public IActionResult Get()
        {
            return Ok(personagens);
        }

        [HttpGet("GetByNome/{nome}")]
        public IActionResult GetByNome(string nome)
        {
            nome = nome.ToLower();

            var personagemEncontrado = personagens.FirstOrDefault(p => p.Nome.ToLower() == nome);

            if (personagemEncontrado == null)
            {
                return NotFound($"Personagem com o nome '{nome}' não encontrado.");
            }

            return Ok(personagemEncontrado);
        }

        [HttpPost("PostValidacao")]
        public IActionResult PostValidacao(Personagem novoPersonagem)
        {
            if (novoPersonagem.Defesa < 10 || novoPersonagem.Inteligencia > 30)
            {
                return BadRequest("O valor de Defesa deve ser maior que 10 e a Inteligência deve ser maior que 30!");
            }
            personagens.Add(novoPersonagem);

            return Ok(personagens);
        }

        [HttpPost("PostValidacaoMago")]
        public IActionResult PostValidacaoMago(Personagem novoPersonagem)
        {
            if (novoPersonagem.Classe == ClasseEnum.Mago && novoPersonagem.Inteligencia < 35)
            {
                return BadRequest("Um personagem do tipo Mago deve ter a inteligência igual ou maior que 35");
            }
            personagens.Add(novoPersonagem);
            return Ok(personagens);
        }

        [HttpGet("GetClerigoMago")]
        public IActionResult GetClerigoMago()
        {
            personagens.RemoveAll(p => p.Classe == ClasseEnum.Cavaleiro);
            personagens = personagens.OrderByDescending(p => p.PontosVida).ToList();

            return Ok(personagens);
        }

        [HttpGet("GetEstatisticas")]
        public IActionResult GetEstatisticas()
        {
            int quantidadePersonagens = personagens.Count;
            int somatorioInteligencia = personagens.Sum(p => p.Inteligencia);

            var estatisticas = new
            {
                QuantidadePersonagens = quantidadePersonagens,
                SomatorioInteligencia = somatorioInteligencia
            };

            return Ok(estatisticas);
        }

        [HttpGet("GetByClasse/{idClasse}")]
        public IActionResult GetByClasse(int idClasse)
        {

            ClasseEnum enumDigitado = (ClasseEnum)idClasse;
            List<Personagem> personagensClasse = personagens.Where(p => p.Classe == enumDigitado).ToList();

            return Ok(personagensClasse);
        }
    }
}