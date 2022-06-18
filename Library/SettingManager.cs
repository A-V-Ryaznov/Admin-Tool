using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdminTool.Library
{
    class SettingManager
    {
        public static int MaximumCountPlayers { get; set; } = 48;

        public static void ReturnToStandard()
        {
            MaximumCountPlayers = 48;
        }

    }
}
