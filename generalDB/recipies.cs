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
    
    public partial class recipies
    {
        public int rp_id { get; set; }
        public int rp_prid { get; set; }
        public int rp_pacid { get; set; }
        public int rp_medid { get; set; }
        public string rp_observations { get; set; }
    
        public virtual medicines medicines { get; set; }
        public virtual patient patient { get; set; }
        public virtual procedures procedures { get; set; }
    }
}
