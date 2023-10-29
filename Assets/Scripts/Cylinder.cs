using System.Collections.Generic;
using UnityEngine;

namespace SuperCylinder
{
    [RequireComponent(typeof(CapsuleCollider))]
    [RequireComponent(typeof(Rigidbody))]
    public class Cylinder: MonoBehaviour, IUpgradable<Cube>
    {
        public IReadOnlyDictionary<Transform, Cube> BodyKits => _cubes;
        private Dictionary<Transform, Cube> _cubes;

        private void Awake() 
        {
            GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeAll ^ RigidbodyConstraints.FreezePositionY;
        }

        public void Init(List<Cube> cubes)
        {
            _cubes = new Dictionary<Transform, Cube>();

            foreach (var cube in cubes)
            {
                AddKit(cube);
            }
        }

        public void HideKits()
        {
            foreach (var cube in _cubes)
            {
                cube.Value.gameObject.SetActive(false);
            }
        }

        public void AddKit(Cube cube)
        {
            _cubes[cube.transform] = cube;
        }

        public void RemoveKit(Cube cube)
        {
            if (_cubes.ContainsKey(cube.transform))
            {
                _cubes.Remove(cube.transform);
            }
        }
    }
}