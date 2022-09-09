using System.ComponentModel.DataAnnotations;
namespace gestion_assoc.Models
{
    public class Activite
    {

        public Guid Id { get; set; }
        [MaxLength(100)]
        [Required]
        public string Nom { get; set; }

        [MaxLength(100)]
        public string Libelle { get; set; }


        public DateTime Date_prev { get; set; }
        public DateTime Date_exec { get; set; }


        [MaxLength(100)]
        [Required]
        public string Type { get; set; }


        [MaxLength(100)]
        public string Besoins { get; set; }
        

        [MaxLength(100)]
        public string CompteRendu { get; set; }
        

        [MaxLength(100)]
        [Required]
        public string Lieu { get; set; }


    }
}
