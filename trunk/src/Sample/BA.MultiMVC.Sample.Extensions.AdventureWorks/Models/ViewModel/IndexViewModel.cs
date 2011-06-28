using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BA.MultiMvc.Framework;
using BA.MultiMvc.Sample.Models.ViewModel;

namespace BA.MultiMvc.Sample.Extensions.AdventureWorks.ViewModel
{
    public class IndexViewModel:HomeVM
    {
        public IndexViewModel(TenantContext context, IDictionary<string,string> resources)
            :base (context,resources){}

        public string UserName { get { return "Geoffrey"; } }
    }
}
