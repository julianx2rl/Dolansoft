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
    
    public partial class TASK
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public TASK()
        {
            this.MILESTONE = new HashSet<MILESTONE>();
        }
    
        public int TASK_ID { get; set; }
        public int STORY_ID { get; set; }
        public Nullable<int> RESPONSIBLE_ID { get; set; }
        public int BACKLOG_ID { get; set; }
        public int PROJECT_ID { get; set; }
        public string DESCRIPTIONS { get; set; }
        public Nullable<int> ESTIMATED_TIME { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<MILESTONE> MILESTONE { get; set; }
        public virtual USER_STORY USER_STORY { get; set; }
        public virtual USERS USERS { get; set; }
    }
}