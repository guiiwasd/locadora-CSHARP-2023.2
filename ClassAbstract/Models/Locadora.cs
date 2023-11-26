using System.ComponentModel;

namespace ClassAbstract.Models
{
    public class Locadora
    {
        [DisplayName("Código")]
        public long? LocadoraId { get; set; }
        public string Nome { get; set; }

        [DisplayName("Descricao")]
        public string Descricao { get; set; }
    }
}

