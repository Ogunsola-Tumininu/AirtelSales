//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace AirtelSales.DAL
{
    using System;
    using System.Collections.Generic;
    
    public partial class sf_user_roles
    {
        public int ROLE_ID { get; set; }
        public string ROLE_NAME { get; set; }
        public int PSWD_LIFE_DAYS { get; set; }
        public Nullable<int> USER_LEVEL { get; set; }
        public Nullable<int> CREATED_BY { get; set; }
        public Nullable<System.DateTime> CREATED_DATE { get; set; }
        public Nullable<int> LAST_MODIFIED_BY { get; set; }
        public Nullable<System.DateTime> LAST_MODIFIED_DATE { get; set; }
        public Nullable<bool> IS_DEFAULT { get; set; }
        public Nullable<int> PARENT_ID { get; set; }
    }
}
