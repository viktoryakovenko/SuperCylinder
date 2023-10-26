using System.Collections.Generic;
using UnityEngine;

namespace SuperCylinder
{
    public class Cube : MonoBehaviour, IUpgradable<Sphere>, IPickable
    {
        public IReadOnlyList<Sphere> BodyKits => _balls;

        private List<Sphere> _balls;

        public Cube(List<Sphere> balls)
        {
            _balls = balls;
        }

        public void AddKit(Sphere kit)
        {
            _balls.Add(kit);
        }

        public void RemoveKit(Sphere kit)
        {
            _balls.Remove(kit);
        }

        public void PickUp()
        {
            Debug.Log("destroying");
            gameObject.GetComponent<MeshRenderer>().material.color = Color.blue;
        }
    }
}
