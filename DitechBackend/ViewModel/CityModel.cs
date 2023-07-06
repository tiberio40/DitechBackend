using Newtonsoft.Json;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Resources;

namespace DitechBackend.ModelDTO
{
    public class CityModel
    {
        [Required(ErrorMessage = "Este campo nombre es obligatorio")]        
        public string Description { get; set; }
    }
}
