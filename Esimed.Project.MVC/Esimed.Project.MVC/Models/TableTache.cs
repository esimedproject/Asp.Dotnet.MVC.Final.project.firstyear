//------------------------------------------------------------------------------
// <auto-generated>
//     Ce code a été généré à partir d'un modèle.
//
//     Des modifications manuelles apportées à ce fichier peuvent conduire à un comportement inattendu de votre application.
//     Les modifications manuelles apportées à ce fichier sont remplacées si le code est régénéré.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Esimed.Project.MVC.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class TableTache
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public TableTache()
        {
            this.TableJalon = new HashSet<TableJalon>();
        }
    
        public int TacheId { get; set; }
        public string TacheNom { get; set; }
        public string TacheUsername { get; set; }
        public string TacheTrigramme { get; set; }
        public Nullable<int> TacheDate { get; set; }
        public Nullable<int> TacheExigence { get; set; }
    
        public virtual TableDate TableDate { get; set; }
        public virtual TableExigence TableExigence { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TableJalon> TableJalon { get; set; }
    }
}
