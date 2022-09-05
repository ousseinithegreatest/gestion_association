namespace gestion_assoc.Models
{
    public class AddAssociationViewModel
    {
        public string Nom { get; set; }
        public DateTime Annee_Creation { get; set; }
        public int Tel_1 { get; set; }
        public int? Tel_2 { get; set; }
        public string Email { get; set; }
        public string Adresse { get; set; }
    }
}
