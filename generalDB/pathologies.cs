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
    
    public partial class pathologies
    {
        public pathologies()
        {
            this.patient_record = new HashSet<patient_record>();
            this.treatments = new HashSet<treatments>();
        }
    
        public int thos_id { get; set; }
        public string thos_type { get; set; }
        public string thos_name { get; set; }
        public string thos_risk { get; set; }
    
        public virtual ICollection<patient_record> patient_record { get; set; }
        public virtual ICollection<treatments> treatments { get; set; }
    }
}
