//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace generalDB
{
    using System;
    using System.Collections.Generic;
    
    public partial class receivables
    {
        public receivables()
        {
            this.payment_history = new HashSet<payment_history>();
        }
    
        public int rv_id { get; set; }
        public int rv_pacid { get; set; }
        public int rv_tmid { get; set; }
        public int rv_prid { get; set; }
        public Nullable<float> rv_amount { get; set; }
    
        public virtual patient patient { get; set; }
        public virtual ICollection<payment_history> payment_history { get; set; }
        public virtual procedures procedures { get; set; }
        public virtual treatment_plan treatment_plan { get; set; }
    }
}
