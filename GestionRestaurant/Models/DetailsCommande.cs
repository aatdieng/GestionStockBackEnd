//------------------------------------------------------------------------------
// <auto-generated>
//     Ce code a été généré à partir d'un modèle.
//
//     Des modifications manuelles apportées à ce fichier peuvent conduire à un comportement inattendu de votre application.
//     Les modifications manuelles apportées à ce fichier sont remplacées si le code est régénéré.
// </auto-generated>
//------------------------------------------------------------------------------

namespace GestionRestaurant.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class DetailsCommande
    {
        public long DetailsID { get; set; }
        public Nullable<long> CommandeID { get; set; }
        public Nullable<int> ProduitID { get; set; }
        public Nullable<int> Quantite { get; set; }
    
        public virtual Commande Commande { get; set; }
        public virtual Produit Produit { get; set; }
    }
}
