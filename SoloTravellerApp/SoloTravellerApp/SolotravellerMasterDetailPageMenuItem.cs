using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoloTravellerApp
{

    public class SolotravellerMasterDetailPageMenuItem
    {
        public SolotravellerMasterDetailPageMenuItem()
        {
            TargetType = typeof(SolotravellerMasterDetailPageDetail);
        }
        public int Id { get; set; }
        public string Title { get; set; }

        public Type TargetType { get; set; }
    }
}