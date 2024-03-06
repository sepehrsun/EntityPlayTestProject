using System;

namespace EntityPlayTestProject.Domain
{
    public class CompanySubject : EnterpriseSubject
    {
        public override string Name { get; set; }
        public virtual string LatinName { get; set; }
        public virtual string Address { get; set; }

    }
}

