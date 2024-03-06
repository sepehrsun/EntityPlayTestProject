using System;
using System.Collections.Generic;
using System.Linq;
using EntityPlayTestProject.Domain;
using EntityPlayTestProject.Domain.Enums;
using NHibernate;
using NHibernate.Cfg;

namespace EntityPlayTestProject.Repositories
{
    public class MaterialRepository : IMaterialRepository
    {
        public void Add(Material material)
        {
            using (ISession session = NHibernateHelper.OpenSession())
            using (ITransaction transaction = session.BeginTransaction())
            {
                EnterpriseSubject enterprise = new EnterpriseSubject();
                enterprise.Id = material.Id;
                enterprise.Name = material.Name + "(" + material.Color + ")";
                enterprise.SubjectType = (int)SubjectType.Material;
                var maxCode = session.Query<EnterpriseSubject>().Max(x => (int?)x.Code);

                enterprise.Code = (int)(maxCode + 1);
                session.Save(enterprise);
                session.Save(material);
                transaction.Commit();
            }
        }

        public Material GetById(Guid id)
        {
            using (ISession session = NHibernateHelper.OpenSession())
                return session.Get<Material>(id);
        }

        public ICollection<Material> GetMaterialList()
        {
            using (ISession session = NHibernateHelper.OpenSession())
            {
                var persons = session
                    .CreateCriteria(typeof(Material))
                    .List<Material>();
                return persons;
            }
        }

        public void Remove(Material material)
        {
            using (ISession session = NHibernateHelper.OpenSession())
            using (ITransaction transaction = session.BeginTransaction())
            {
                session.Delete(material);
                transaction.Commit();
            }
        }

        public void Update(Material material)
        {
            using (ISession session = NHibernateHelper.OpenSession())
            using (ITransaction transaction = session.BeginTransaction())
            {
                session.Update(material);
                transaction.Commit();
            }
        }
    }
}

