//------------------------------------------------------------------------------
// <auto-generated>
//     Ce code a été généré à partir d'un modèle.
//
//     Des modifications manuelles apportées à ce fichier peuvent conduire à un comportement inattendu de votre application.
//     Les modifications manuelles apportées à ce fichier sont remplacées si le code est régénéré.
// </auto-generated>
//------------------------------------------------------------------------------

namespace WebApplication.Esimed.Projet.Service
{
    using System;
    using System.Collections.Generic;
    
    public partial class TableTacheExigence
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public TableTacheExigence()
        {
            this.TableTache = new HashSet<TableTache>();
        }
    
        public int TETache { get; set; }
        public int TEExigence { get; set; }
    
        public virtual TableExigence TableExigence { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TableTache> TableTache { get; set; }
    }
}