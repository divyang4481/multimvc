using BA.MultiMvc.Framework.NHibernate;

namespace BA.MultiMvc.Framework.NHibernate
{
    /// <summary>
    /// A resource can be anything that's languagve dependent
    /// </summary>
    public class Resource: Entity
    {
        public virtual string Language { get; set; }
        public virtual string Label { get; set; }
        public virtual string Value { get; set; }
    }
}