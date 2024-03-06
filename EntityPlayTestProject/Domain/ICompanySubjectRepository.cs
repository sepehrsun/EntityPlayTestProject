using System;
using System.Collections.Generic;

namespace EntityPlayTestProject.Domain
{
    public interface ICompanySubjectRepository
    {
        void Add(CompanySubject company);

        void Update(CompanySubject company);

        void Remove(CompanySubject company);

        CompanySubject GetById(Guid id);

        ICollection<CompanySubject> GetCompanySubjectList();
    }
}