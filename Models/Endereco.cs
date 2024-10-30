using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Checkpoint1GabrielPescarolli.Models
{
    [Table("CP_ENDERECOS")]
    public class Endereco
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        public string CEP { get; set; }
        [Required]
        public string Cidade { get; set; }
        public string Estado { get; set; }
        public string Bairro { get; set; }
        public string Logradouro { get; set; }

        public Endereco() { }

        public Endereco(string cep, string cidade, string estado, string bairro, string logradouro)
        {
            CEP = cep;
            Cidade = cidade;
            Estado = estado;
            Bairro = bairro;
            Logradouro = logradouro;
        }
    }
}
