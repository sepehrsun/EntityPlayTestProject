using System;

namespace EntityPlayTestProject.Domain
{
    public class EnterpriseSubject
    {
        public virtual Guid Id { get; set; }
        public virtual int Code { get; set; }
        public virtual string Name { get; set; }
        public virtual int SubjectType { get; set; }

    }
}

