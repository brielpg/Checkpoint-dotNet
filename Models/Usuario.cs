using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Checkpoint1GabrielPescarolli.Models
{
    [Table("CP_USUARIOS")]
    public class Usuario
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        public string Nome { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public DateTime DataNascimento { get; set; }

        public virtual Endereco Endereco { get; set; }

        public Usuario() { }

        public Usuario(string nome, string email, DateTime dataNascimento, Endereco endereco)
        {
            Nome = nome;
            Email = email;
            DataNascimento = dataNascimento;
            Endereco = endereco;
        }
    }
}
