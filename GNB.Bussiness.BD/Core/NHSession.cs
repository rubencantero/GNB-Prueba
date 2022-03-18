using NHibernate;
using NHibernate.Cfg;
using NHibernate.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace GNB.Bussiness.BD.Core
{
    public class NHSession:IDisposable
    {
        protected static ISessionFactory sessionFactory;
        public static bool isConection = true;
        public NHSession()
        {           
        }


        public static ISession GetCurrentSession() {
            try
            {
                if (sessionFactory == null)
                {
                    Configuration c = new Configuration().Configure();
                    sessionFactory = c.BuildSessionFactory();
                }
                if (CurrentSessionContext.HasBind(sessionFactory))
                {
                    return sessionFactory.GetCurrentSession();
                    //escribirLog
                }
                var session = sessionFactory.OpenSession();
                CurrentSessionContext.Bind(session);
                session.BeginTransaction();
                return session;
                
            }
            catch (Exception)
            {
                isConection = false;
                return null;
            }


        }
        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}
