using System;
using System.Collections.Generic;
using eDrugs.ApplicationCore.Enums;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace eDrugs.Models
{
    public class DrugMfgInfoViewModel
    {
        public Guid Id { get; set; }
        public TypeOfDrugs TypeOfDrugs { get; set; }
        public string UnitAmount { get; set; }
        public double Mrp { get; set; }
        public Guid DrugId { get; set; }
        public DateTime MfgDate { get; set; }
        public DateTime ExpDate { get; set; }
        public IList<SelectListItem> Drugs { get; set; }

    }
}