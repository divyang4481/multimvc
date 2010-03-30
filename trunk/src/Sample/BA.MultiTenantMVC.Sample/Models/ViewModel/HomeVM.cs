using System.Collections.Generic;
using BA.MultiMvc.Framework;

namespace BA.MultiMvc.Sample.Models.ViewModel
{
    public class HomeVM:BaseViewModel
    {
        public HomeVM(TenantContext context)
            : base(context)
        {}

    

        public string  Message { get; set; }
    }
}
