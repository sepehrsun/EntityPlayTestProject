using System;
using System.Collections.Generic;

namespace EntityPlayTestProject.Domain
{
    public interface IPersonSubjectRepository
    {
        void Add(PersonSubject person);

        void Update(PersonSubject person);

        void Remove(PersonSubject person);

        PersonSubject GetById(Guid id);

        ICollection<PersonSubject> GetPersonSubjectList();
    }
}