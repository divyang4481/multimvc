using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BA.MultiMvc.Sample.Models.ViewModel;
using BA.MultiMvc.Framework.Core;

namespace BA.MultiMvc.Sample.Extensions.AdventureWorks.ViewModel
{
    public class IndexViewModel:HomeVM
    {
        public IndexViewModel(TenantContext context, IDictionary<string,string> resources)
            :base (context){}

        public string UserName { get { return "Geoffrey"; } }
    }
}
