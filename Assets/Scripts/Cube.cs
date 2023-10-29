using System.Collections.Generic;
using UnityEngine;

namespace SuperCylinder
{
    [RequireComponent(typeof(BoxCollider))]
    [RequireComponent(typeof(Rigidbody))]
    public class Cube : ChildNode, IUpgradable<Sphere>
    {
        public IReadOnlyDictionary<Transform, Sphere> BodyKits => _spheres;

        private Dictionary<Transform, Sphere> _spheres;

        private void OnCollisionEnter(Collision other) 
        {
            if (other.collider.GetComponent<Cylinder>()) 
            {
                Parent = other.collider;
            }
        }

        public void Init(List<Sphere> spheres)
        {
            _spheres = new Dictionary<Transform, Sphere>();

            foreach (var sphere in spheres)
            {
                AddKit(sphere);
            }
        }

        public void HideKits()
        {
            foreach (var sphere in _spheres)
            {
                sphere.Value.gameObject.SetActive(false);
            }
        }

        public void AddKit(Sphere sphere)
        {
            _spheres[sphere.transform] = sphere;
        }

        public void RemoveKit(Sphere sphere)
        {
            if (_spheres.ContainsKey(sphere.transform))
            {
                _spheres.Remove(sphere.transform);
            }
        }
    }
}
