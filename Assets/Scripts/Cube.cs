using System.Collections.Generic;
using UnityEngine;

namespace SuperCylinder
{
    public class Cube : MonoBehaviour, IUpgradable<Sphere>, IPickable
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

        public void PickUp()
        {
            Debug.Log("Cube picked up");
            gameObject.GetComponent<MeshRenderer>().material.color = Color.blue;
        }

        public void Drop()
        {
            Debug.Log("Cube dropped");
            gameObject.GetComponent<MeshRenderer>().material.color = Color.white;
        }
    }
}
