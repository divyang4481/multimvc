using System;
using System.Linq;
using System.IO;
using System.IO.IsolatedStorage;
using System.Collections.Generic;
using Microsoft.LightSwitch;
using Microsoft.LightSwitch.Framework.Client;
using Microsoft.LightSwitch.Presentation;
using Microsoft.LightSwitch.Presentation.Extensions;
namespace LightSwitchApplication
{
    public partial class SearchBadges
    {
        partial void GenerateBadges_Execute()
        {
            for (int i = 0; i < 10; i++)
            {
                Badge badge = this.Badges.AddNew();
                badge.Nbr = i.ToString();
            }

        }
    }
}
