using System;
using System.Collections.Generic;
using eDrugs.ApplicationCore.Enums;

namespace eDrugs.ApplicationCore
{
    public class Drug
    {
        public Guid Id { get; set; }
        public string BatchNo { get; set; }
        public string GenericName { get; set; }
        public string BusinessName { get; set; }

        public IList<DrugMfgInfo> DrugMfgInfos { get; set; }
    }

}