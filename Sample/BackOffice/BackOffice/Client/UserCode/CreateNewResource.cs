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
    public partial class CreateNewResource
    {
        partial void CreateNewResource_InitializeDataWorkspace(global::System.Collections.Generic.List<global::Microsoft.LightSwitch.IDataService> saveChangesTo)
        {
            // Write your code here.
            this.ResourceProperty = new Resource();
        }

        partial void CreateNewResource_Saved()
        {
            // Write your code here.
            this.Close(false);
            Application.Current.ShowDefaultScreen(this.ResourceProperty);
        }

        partial void CreateNewResource_Saving(ref bool handled)
        {
            // Write your code here.
            this.ResourceProperty.Id = Guid.NewGuid();
            this.ResourceProperty.Version = 0;
           
        }
    }
}