using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Checkpoint1GabrielPescarolli.Models
{
    [Table("CP_JOGOS")]
    public class Jogo
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        public string Nome { get; set; }

        [Required]
        public string Desenvolvedora { get; set; }

        [Required]
        public string Genero { get; set; }

        [Required]
        public decimal Preco { get; set; }

        public Jogo() { }

        public Jogo(string nome, string desenvolvedora, string genero, decimal preco)
        {
            Nome = nome;
            Desenvolvedora = desenvolvedora;
            Genero = genero;
            Preco = preco;
        }
    }
}
