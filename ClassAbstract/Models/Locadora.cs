using System.ComponentModel;

namespace ClassAbstract.Models
{
    public class Locadora
    {
        [DisplayName("Código")]
        public long? FilmeId { get; set; }
        public string Nome { get; set; }

        [DisplayName("Quantidade")]
        public string Quantidade { get; set; }
    }
}

