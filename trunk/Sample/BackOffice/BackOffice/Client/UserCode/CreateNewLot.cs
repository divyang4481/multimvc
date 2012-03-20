using System;
using System.Linq;
using System.IO;
using System.IO.IsolatedStorage;
using System.Collections.Generic;
using Microsoft.LightSwitch;
using Microsoft.LightSwitch.Framework.Client;
using Microsoft.LightSwitch.Presentation;
using Microsoft.LightSwitch.Presentation.Extensions;
using System.Text;

namespace LightSwitchApplication
{
    public partial class CreateNewLot
    {
        partial void CreateNewLot_InitializeDataWorkspace(global::System.Collections.Generic.List<global::Microsoft.LightSwitch.IDataService> saveChangesTo)
        {
            // Write your code here.
            this.LotProperty = new Lot();
        }

        partial void CreateNewLot_Saved()
        {
            // Write your code here.
            this.Close(false);
            Application.Current.ShowDefaultScreen(this.LotProperty);
        }

        partial void CreateNewLot_Saving(ref bool handled)
        {
            this.LotProperty.Id = Guid.NewGuid();
            this.LotProperty.RegistrationDate = DateTime.Now;
            this.LotProperty.Version = 0;

            for (int i = 0; i < this.LotProperty.Amount; i++)
            {
                Badge badge = new Badge();
                badge.Lot = this.LotProperty;
                badge.Nbr = GenerateRandomString(9);
            }
        }

        private static Random _random = new Random();

        public static string GenerateRandomString(int size)
        {
            StringBuilder builder = new StringBuilder();
            for (int i = 0; i < size; i++)
            {
                //26 letters in the alfabet, ascii + 65 for the capital letters
                if (_random.NextDouble() > 0.3846153846153846)
                    builder.Append(Convert.ToChar(Convert.ToInt32(Math.Floor(26 * _random.NextDouble() + 65))));
                else
                    builder.Append(Convert.ToInt32(Math.Floor(10 * _random.NextDouble())));

            }
            return builder.ToString();
        }
    }
}