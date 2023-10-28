using System.Collections.Generic;
using UnityEngine;

namespace SuperCylinder
{
    [RequireComponent(typeof(Rigidbody))]
    public class Cylinder : MonoBehaviour, IUpgradable<Cube>
    {
        public IReadOnlyList<Cube> BodyKits => _cubes;
        private List<Cube> _cubes;

        private void Awake() 
        {
            GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeAll ^ RigidbodyConstraints.FreezePositionY;
        }

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