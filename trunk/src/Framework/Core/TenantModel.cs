namespace BA.MultiMVC.Framework.Core
{
    public class TenantModel:ITenantModel 
    {
        public TenantContext Context
        {
            get; set;
        }
    }
}
