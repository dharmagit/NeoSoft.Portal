using System;
using System.Collections.Generic;
using System.Text;

namespace NeoSoft.Portal.Model
{
    public class BrandMaster
    {
        public int BrandId { get; set; }
        public string BrandName { get; set; }
    }

    public class Setting
    {
        public List<SettingMaster> settingMasters { get; set; }
    }

    public class SettingMaster
    {
        public string SettingName { get; set; }
        public string SettingValue { get; set; }

        public string SettingTitle { get; set; }
        public bool IsEnabled { get; set; }
    }
    public class ColorMaster
    {
        public string ColorName { get; set; }
    }
    public class SizeMaster
    {
        public string SizeName { get; set; }
    }
}
