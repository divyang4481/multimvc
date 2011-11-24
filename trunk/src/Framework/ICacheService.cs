namespace BA.MultiMvc.Framework
{
    /// <summary>
    /// Defines a contract for a CacheService
    /// </summary>
    public interface ICacheService:ITenantModel
    {
        object GetObject(string key);
        void Add(string key, object value);
    }
}