using System.Collections.Generic;

namespace SuperCylinder
{
    public class Cube : PickableObject, IUpgradable<Sphere>
    {
        public IReadOnlyList<Sphere> BodyKits => _spheres;

        private List<Sphere> _spheres;

        public void AddKit(Sphere kit)
        {
            _spheres.Add(kit);
        }

        public void RemoveKit(Sphere kit)
        {
            _spheres.Remove(kit);
        }
    }
}
