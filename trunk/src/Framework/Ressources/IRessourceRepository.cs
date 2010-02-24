using System;
using System.Collections.Generic;
using BA.MultiMVC.Framework.Core;

namespace BA.MultiMVC.Framework.Ressources
{
    public interface IRessourceRepository:IRepository
    {
        IDictionary<string, string> Find(string language);
    }
}
