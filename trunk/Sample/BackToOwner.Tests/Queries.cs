using System.Linq;
using BA.MultiMVC.Framework.NHibernate;
using BackToOwner.Golf.Web.Models;
using NHibernate;
using NHibernate.Linq;

namespace BackToOwner.Golf.Web.Test
{
    public class Queries
    {
        private static ISessionFactory sessionFactory;

         static Queries()
        {
            sessionFactory = NHHelper.GetSessionFactoryFor("Default");
        }

        public static ISession OpenSession()
        {
            return sessionFactory.OpenSession();
        }

        public static IQueryable<Owner> RetrieveOwner(ISession session, Owner memOwner)
        {
            return from o in session.Query<Owner>()
                   where o.EmailAddresses[0] == memOwner.EmailAddresses[0]
                   select o;
        }

        public static IQueryable<Declaration> RetrieveDeclaration(ISession session, Declaration declaration)
        {
            return from o in session.Query<Declaration>()
                   where o.Id == declaration.Id
                   select o;
        }
    }
}
