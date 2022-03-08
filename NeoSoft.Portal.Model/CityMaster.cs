using System;
using System.Collections.Generic;
using System.Text;

namespace NeoSoft.Portal.Model
{
    public class CityMaster
    {
        public object CityId { get; set; } = default(Int32);
        public object CityName { get; set; } = string.Empty;
        public object StateId { get; set; } = default(Int32);
    }
}
