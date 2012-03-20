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
    public partial class DeclarationDetail
    {
        partial void Declaration_Loaded(bool succeeded)
        {
            // Write your code here.
            this.SetDisplayNameFromEntity(this.Declaration);
        }

        partial void Declaration_Changed()
        {
            // Write your code here.
            this.SetDisplayNameFromEntity(this.Declaration);
        }

        partial void DeclarationDetail_Saved()
        {
            // Write your code here.
            this.SetDisplayNameFromEntity(this.Declaration);
        }
    }
}