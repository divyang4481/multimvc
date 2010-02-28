namespace BA.MultiMVC.Framework.Core
{
    public interface IService
    {
        TenantContext Context { get; set; }
    }
}