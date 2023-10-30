using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace SuperCylinder
{
    [RequireComponent(typeof(BoxCollider))]
    public class Cube : ChildNode, IUpgradable
    {
        public IReadOnlyDictionary<Transform, Collider> BodyKits => _spheres;

        private Dictionary<Transform, Collider> _spheres;

        private void Awake()
        {
            _spheres = new Dictionary<Transform, Collider>();

            var boxCollider = GetComponent<BoxCollider>();

            var center = boxCollider.transform.position;
            var halfExtents = boxCollider.transform.localScale;
            var quaternion = boxCollider.transform.localRotation;

            List<Collider> overlapColliders = Physics.OverlapBox(center, halfExtents, quaternion)
                                                .Where(col => col.GetType() == typeof(SphereCollider)).ToList();

            foreach(var col in overlapColliders)
            {
                Debug.Log(col);
                if (col.TryGetComponent(out Sphere sphere))
                {
                    sphere.Parent = GetComponent<Collider>();
                    AddKit(sphere.GetComponent<SphereCollider>());
                }
            }
        }

        public void HideKits()
        {
            foreach (var sphere in _spheres)
            {
                sphere.Value.gameObject.SetActive(false);
            }
        }

        public void AddKit(Collider sphere)
        {
            _spheres[sphere.transform] = sphere;
        }

        public void RemoveKit(Collider sphere)
        {
            if (_spheres.ContainsKey(sphere.transform))
            {
                _spheres.Remove(sphere.transform);
            }
        }
    }
}
