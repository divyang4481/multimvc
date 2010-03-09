namespace BA.MultiMVC.Framework.Core
{
    public interface ITenantModel
    {
        TenantContext Context { get; set; }
    }
}