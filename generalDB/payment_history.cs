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
    
    public partial class payment_history
    {
        public int pay_id { get; set; }
        public int pay_pacid { get; set; }
        public Nullable<int> pay_rvid { get; set; }
        public Nullable<float> pay_amount { get; set; }
        public System.DateTime pay_date { get; set; }
        public string pay_mode { get; set; }
    }
}
