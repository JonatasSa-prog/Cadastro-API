using System.ComponentModel.DataAnnotations;

namespace Cadastro_API.ViewModels
{
    public class PersonViewModel
    {
        [Required]
        public string name { get; set; }
        [Required]
        public string sex { get; set; }
        [Required]
        public DateTime birth { get; set; }
    }
}
