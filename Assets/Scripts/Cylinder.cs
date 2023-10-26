using System.Collections.Generic;
using UnityEngine;

namespace SuperCylinder
{
    public class Cylinder : MonoBehaviour, IUpgradable<Cube>
    {
        public IReadOnlyList<Cube> BodyKits => _cubes;
        private List<Cube> _cubes;

        public void AddKit(Cube cube)
        {
            _cubes.Add(cube);
        }

        public void RemoveKit(Cube cube)
        {
            _cubes.Remove(cube);
        }
    }
}