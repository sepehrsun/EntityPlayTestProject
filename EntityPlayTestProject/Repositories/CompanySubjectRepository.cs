using System;
using System.Collections.Generic;
using System.Linq;
using EntityPlayTestProject.Domain;
using EntityPlayTestProject.Domain.Enums;
using NHibernate;
using NHibernate.Cfg;

namespace EntityPlayTestProject.Repositories
{
    public class CompanySubjectRepository : ICompanySubjectRepository
    {
        public void Add(CompanySubject company)
        {
            using (ISession session = NHibernateHelper.OpenSession())
            using (ITransaction transaction = session.BeginTransaction())
            {
                EnterpriseSubject enterprise = new EnterpriseSubject();
                enterprise.Id = company.Id;
                enterprise.Name = company.Name + "(" + company.LatinName + ")";
                enterprise.SubjectType = (int)SubjectType.CompanySubject;
                var maxCode = session.Query<EnterpriseSubject>().Max(x => (int?)x.Code);

                enterprise.Code = (int)(maxCode + 1);
                session.Save(enterprise);
                session.Save(company);
                transaction.Commit();
            }
        }

        public CompanySubject GetById(Guid id)
        {
            using (ISession session = NHibernateHelper.OpenSession())
                return session.Get<CompanySubject>(id);
        }

        public ICollection<CompanySubject> GetCompanySubjectList()
        {
            using (ISession session = NHibernateHelper.OpenSession())
            {
                var persons = session
                    .CreateCriteria(typeof(CompanySubject))
                    .List<CompanySubject>();
                return persons;
            }
        }

        public void Remove(CompanySubject company)
        {
            using (ISession session = NHibernateHelper.OpenSession())
            using (ITransaction transaction = session.BeginTransaction())
            {
                session.Delete(company);
                transaction.Commit();
            }
        }

        public void Update(CompanySubject company)
        {
            using (ISession session = NHibernateHelper.OpenSession())
            using (ITransaction transaction = session.BeginTransaction())
            {
                session.Update(company);
                transaction.Commit();
            }
        }
    }
}

