using EntityPlayTestProject.Domain;

using NHibernate;

using NHibernate.Cfg;

namespace EntityPlayTestProject.Repositories

{

    public class NHibernateHelper

    {

        private static ISessionFactory _sessionFactory;



        private static ISessionFactory SessionFactory

        {

            get

            {

                if (_sessionFactory == null)

                {

                    var configuration = new Configuration();

                    configuration.Configure();

                    configuration.AddAssembly(typeof(EnterpriseSubject).Assembly);

                    _sessionFactory = configuration.BuildSessionFactory();

                }

                return _sessionFactory;

            }

        }



        public static ISession OpenSession()

        {

            return SessionFactory.OpenSession();

        }

    }

}

