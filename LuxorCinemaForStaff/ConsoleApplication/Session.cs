//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ConsoleApplication
{
    using System;
    using System.Collections.Generic;
    
    public partial class Session
    {
        public int ID { get; set; }
        public Nullable<System.TimeSpan> Start { get; set; }
        public System.TimeSpan Finish { get; set; }
        public System.DateTime Date { get; set; }
    
        public virtual Film Film { get; set; }
        public virtual Hall Hall { get; set; }
    }
}
