using System;

namespace EntityPlayTestProject.Domain
{
    public class Material : EnterpriseSubject
    {

        public override string Name { get; set; }
        public int Weight { get; set; }
        public string Color { get; set; }
        public string UnitOfMeasureName { get; set; }


    }
}

