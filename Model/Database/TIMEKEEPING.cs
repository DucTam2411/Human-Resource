//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Model.Database
{
    using System;
    using System.Collections.Generic;
    
    public partial class TIMEKEEPING
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public TIMEKEEPING()
        {
            this.TIMEKEEPING_DETAIL = new HashSet<TIMEKEEPING_DETAIL>();
        }
    
        public int TIMEKEEPING_ID { get; set; }
        public Nullable<int> EMPLOYEE_ID { get; set; }
        public Nullable<int> NUMBER_OF_WORK_DAY { get; set; }
        public Nullable<int> NUMBER_OF_ABSENT_DAY { get; set; }
        public Nullable<int> NUMBER_OF_OVERTIME_DAY { get; set; }
    
        public virtual EMPLOYEE EMPLOYEE { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TIMEKEEPING_DETAIL> TIMEKEEPING_DETAIL { get; set; }
    }
}
