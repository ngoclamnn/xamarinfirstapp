using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoloTravellerApp
{

    public class SoloMasterDetailMenuItem
    {
        public SoloMasterDetailMenuItem()
        {
            TargetType = typeof(SoloMasterDetailDetail);
        }
        public int Id { get; set; }
        public string Title { get; set; }

        public Type TargetType { get; set; }
    }
}