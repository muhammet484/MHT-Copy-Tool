using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CopyTool
{
    public enum CutOrCopySetting { Cut, Copy }
    public enum FileNameSetting
    { ShowFullPath, ShowNameWithExtension, ShowNameOnly }

    public static class Settings
    {
        public static FileNameSetting fileNameSetting =
            FileNameSetting.ShowNameWithExtension;
        public static CutOrCopySetting CutOrCopySetting;
    }
}
