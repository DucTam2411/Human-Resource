//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace HRMS.Director.Model
{
    using System;
    using System.Collections.Generic;
    
    public partial class ROLE
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public ROLE()
        {
            this.EMPLOYEEs = new HashSet<EMPLOYEE>();
        }
    
        public int ROLE_ID { get; set; }
        public Nullable<int> PERMISSION { get; set; }
        public string ROLE_NAME { get; set; }
        public string ROLE_DESC { get; set; }
        public Nullable<int> DEPT_ID { get; set; }
    
        public virtual DEPARTMENT DEPARTMENT { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<EMPLOYEE> EMPLOYEEs { get; set; }
    }
}