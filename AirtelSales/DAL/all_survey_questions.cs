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
    
    public partial class all_survey_questions
    {
        public int Id { get; set; }
        public int SurveyId { get; set; }
        public string SurveyQuestion { get; set; }
        public string ResponseType { get; set; }
        public string DomainValues { get; set; }
        public string SurvAns { get; set; }
        public Nullable<int> SurveyQuestionOrder { get; set; }
    }
}
