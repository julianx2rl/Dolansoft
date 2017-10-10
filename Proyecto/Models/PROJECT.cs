//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Proyecto.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class PROJECT
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public PROJECT()
        {
            this.BACKLOG = new HashSet<BACKLOG>();
            this.USERS1 = new HashSet<USERS>();
        }
    
        public int PROJECT_ID { get; set; }
        public Nullable<System.DateTime> STARTING_DATE { get; set; }
        public Nullable<System.DateTime> FINAL_DATE { get; set; }
        public string DESCRIPTIONS { get; set; }
        public string PROJECT_NAME { get; set; }
        public Nullable<int> LEADER_ID { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<BACKLOG> BACKLOG { get; set; }
        public virtual USERS USERS { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<USERS> USERS1 { get; set; }
    }
}
