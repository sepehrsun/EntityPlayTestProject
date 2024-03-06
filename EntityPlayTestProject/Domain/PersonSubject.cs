using System;

namespace EntityPlayTestProject.Domain
{
    public class PersonSubject : EnterpriseSubject
    {
        public virtual string FirsName { get; set; }
        public virtual string LastName { get; set; }
        public virtual string PhoneNumber { get; set; }

    }
}

