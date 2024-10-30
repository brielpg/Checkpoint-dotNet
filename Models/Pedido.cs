using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Checkpoint1GabrielPescarolli.Models
{
    [Table("CP_PEDIDOS")]
    public class Pedido
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        public int UsuarioId { get; set; }

        [Required]
        public int JogoId { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public DateTime DataPedido { get; set; }

        public Pedido() { }

        public Pedido(int usuarioId, int jogoId, DateTime dataPedido)
        {
            UsuarioId = usuarioId;
            JogoId = jogoId;
            DataPedido = dataPedido;
        }
    }
}
