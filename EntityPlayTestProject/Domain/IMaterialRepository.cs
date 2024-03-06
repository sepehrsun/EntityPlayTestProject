using System;
using System.Collections.Generic;

namespace EntityPlayTestProject.Domain
{
    public interface IMaterialRepository
    {
        void Add(Material material);

        void Update(Material material);

        void Remove(Material material);

        Material GetById(Guid id);

        ICollection<Material> GetMaterialList();
    }
}