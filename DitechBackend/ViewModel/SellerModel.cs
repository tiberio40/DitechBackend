using DAL.Models;
using DitechBackend.ModelDTO;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DitechBackend.ViewModel
{
    public class SellerModel
    {
        [Required(ErrorMessage = "Este campo nombre es obligatorio")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Este campo apellido es obligatorio")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Este campo documento es obligatorio")]
        public string Document { get; set; }

        [Required(ErrorMessage = "Este campo ciudad es obligatorio")]
        public int? CityId { get; set; }

        public IEnumerable<CityModel> City { get; set; }




    }
}
