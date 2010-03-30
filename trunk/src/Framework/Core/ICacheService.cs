namespace BA.MultiMvc.Framework.Core
{
    public interface ICacheService:ITenantModel
    {
        object GetObject(string key);

        void Add(string key, object value);
    }
}