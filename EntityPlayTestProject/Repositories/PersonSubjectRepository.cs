using System;
using System.Collections.Generic;
using System.Linq;
using EntityPlayTestProject.Domain;
using EntityPlayTestProject.Domain.Enums;
using NHibernate;
using NHibernate.Cfg;

namespace EntityPlayTestProject.Repositories
{
    public class PersonSubjectRepository : IPersonSubjectRepository
    {
        public void Add(PersonSubject person)
        {
            using (ISession session = NHibernateHelper.OpenSession())
            using (ITransaction transaction = session.BeginTransaction())
            {
                EnterpriseSubject enterprise = new EnterpriseSubject();
                enterprise.Id = person.Id;
                enterprise.Name = person.FirsName + " " + person.LastName;
                enterprise.SubjectType = (int)SubjectType.PersonSubject;
                var maxCode = session.Query<EnterpriseSubject>().Max(x => (int?)x.Code);

                enterprise.Code = (int)(maxCode + 1);
                session.Save(enterprise);
                session.Save(person);
                transaction.Commit();
            }
        }

        public PersonSubject GetById(Guid id)
        {
            using (ISession session = NHibernateHelper.OpenSession())
                return session.Get<PersonSubject>(id);
        }

        public ICollection<PersonSubject> GetPersonSubjectList()
        {
            using (ISession session = NHibernateHelper.OpenSession())
            {
                var persons = session
                    .CreateCriteria(typeof(PersonSubject))
                    .List<PersonSubject>();
                return persons;
            }
        }

        public void Remove(PersonSubject person)
        {
            using (ISession session = NHibernateHelper.OpenSession())
            using (ITransaction transaction = session.BeginTransaction())
            {
                session.Delete(person);
                transaction.Commit();
            }
        }

        public void Update(PersonSubject person)
        {
            using (ISession session = NHibernateHelper.OpenSession())
            using (ITransaction transaction = session.BeginTransaction())
            {
                session.Update(person);
                transaction.Commit();
            }
        }
    }
}

