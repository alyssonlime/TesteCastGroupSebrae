using System.ComponentModel.DataAnnotations;

namespace API.Entity.Model
{
    public class Conta
    {
        public int ID { get; set; }

        [Required(ErrorMessage = "O Nome é obrigatório")]
        [MaxLength(50, ErrorMessage = "O Nome deve ter no máximo 50 caracteres")]
        [MinLength(10, ErrorMessage = "O Nome deve ter no mínimo 10 caracteres")]
        public string Nome { get; set; }

        [MaxLength(150, ErrorMessage = "A Descrição deve ter no máximo 150 caracteres")]
        public string Descricao { get; set; }
    }
}
