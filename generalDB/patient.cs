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
    
    public partial class patient
    {
        public patient()
        {
            this.clinical_history = new HashSet<clinical_history>();
            this.patient_record = new HashSet<patient_record>();
            this.payment_history = new HashSet<payment_history>();
            this.procedures = new HashSet<procedures>();
            this.receivables = new HashSet<receivables>();
            this.recipies = new HashSet<recipies>();
            this.treatment_plan = new HashSet<treatment_plan>();
        }
    
        public int pac_id { get; set; }
        public string pac_ced { get; set; }
        public string pac_name { get; set; }
        public string pac_lastn { get; set; }
        public Nullable<System.DateTime> pac_born { get; set; }
        public string pac_race { get; set; }
        public string pac_phone1 { get; set; }
        public string pac_phone2 { get; set; }
        public string pac_address { get; set; }
        public string pac_job { get; set; }
        public string pac_school { get; set; }
        public string pac_ensur { get; set; }
        public int pac_divId { get; set; }
    
        public virtual ICollection<clinical_history> clinical_history { get; set; }
        public virtual divisions divisions { get; set; }
        public virtual ICollection<patient_record> patient_record { get; set; }
        public virtual ICollection<payment_history> payment_history { get; set; }
        public virtual ICollection<procedures> procedures { get; set; }
        public virtual ICollection<receivables> receivables { get; set; }
        public virtual ICollection<recipies> recipies { get; set; }
        public virtual ICollection<treatment_plan> treatment_plan { get; set; }
    }
}
