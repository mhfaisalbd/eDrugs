using System;
using eDrugs.ApplicationCore.Enums;

namespace eDrugs.ApplicationCore
{
    public class DrugMfgInfo
    {
        public Guid Id { get; set; }
        public TypeOfDrugs TypeOfDrugs { get; set; }
        public string UnitAmount { get; set; }
        public double Mrp { get; set; }

        public Drug Drug { get; set; }
    }
}