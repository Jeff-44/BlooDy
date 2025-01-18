using System.ComponentModel.DataAnnotations;

namespace BlooDyWeb.Models.DistributionModule
{

    //chat : FHIR JUIN/JUILLET 2024
    public class Document : Audit
    {
        public string? Code { get; set; }
        [Required(ErrorMessage = "Vous devez indiquer la Distribution à laquelle ce document sera affecté.")]
        public long IdDistribution { get; set; }
        public Distribution? Distribution { get; set; }
        public string? TypeDocument { get; set; } // enum: PDF, word, Excel ... a reviser
        public string? CheminFichier { get; set; } // a reviser : ajout chemin fichier automatique
    }
}
