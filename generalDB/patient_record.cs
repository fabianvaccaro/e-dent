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
    
    public partial class patient_record
    {
        public int pr_id { get; set; }
        public int pr_pacid { get; set; }
        public int pr_chid { get; set; }
        public int pr_patid { get; set; }
        public string pr_dentalloc { get; set; }
        public string pr_facialloc { get; set; }
        public Nullable<int> pr_gravity { get; set; }
        public string pr_prevtreat { get; set; }
        public string pr_medic { get; set; }
        public Nullable<System.DateTime> pr_regdate { get; set; }
    
        public virtual clinical_history clinical_history { get; set; }
        public virtual pathologies pathologies { get; set; }
        public virtual patient patient { get; set; }
    }
}
