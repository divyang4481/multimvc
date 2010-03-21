namespace BA.MultiMvc.Framework.Core
{
    public interface ITenantModel
    {
        TenantContext Context { get; set; }
    }
}