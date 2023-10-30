using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace SuperCylinder
{
    [RequireComponent(typeof(CapsuleCollider))]
    [RequireComponent(typeof(Rigidbody))]
    public class Cylinder: MonoBehaviour, IUpgradable
    {
        public IReadOnlyDictionary<Transform, Collider> BodyKits => _cubes;

        private Dictionary<Transform, Collider> _cubes;

        private void Awake() 
        {
            _cubes = new Dictionary<Transform, Collider>();
            GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeAll ^ RigidbodyConstraints.FreezePositionY;
            
            var capsuleCollider = GetComponent<CapsuleCollider>();

            var direction = new Vector3 {[capsuleCollider.direction] = 1};
            var offset = capsuleCollider.height / 2 - capsuleCollider.radius;
            var localPoint0 = capsuleCollider.center - direction * offset;
            var localPoint1 = capsuleCollider.center + direction * offset;

            var point0 = transform.TransformPoint(localPoint0);
            var point1 = transform.TransformPoint(localPoint1);

            var r = transform.TransformVector(capsuleCollider.radius, capsuleCollider.radius, capsuleCollider.radius);
            var radius = Enumerable.Range(0, 3).Select(xyz => xyz == capsuleCollider.direction ? 0 : r[xyz])
                .Select(Mathf.Abs).Max();

            List<Collider> overlapColliders = Physics.OverlapCapsule(point0, point1, radius)
                                                .Where(col => col.GetType() == typeof(BoxCollider)).ToList();

            foreach(var col in overlapColliders)
            {
                Debug.Log(col);
                if (col.TryGetComponent(out Cube cube))
                {
                    cube.Parent = GetComponent<Collider>();
                    AddKit(cube.GetComponent<BoxCollider>());
                }
            }
        }

        public void HideKits()
        {
            foreach (var cube in _cubes)
            {
                cube.Value.gameObject.SetActive(false);
            }
        }

        public void AddKit(Collider cube)
        {
            _cubes[cube.transform] = cube;
        }

        public void RemoveKit(Collider cube)
        {
            if (_cubes.ContainsKey(cube.transform))
            {
                _cubes.Remove(cube.transform);
            }
        }

        //TODO
        public void ShowKit(Transform cubeTransform)
        {
            var go = _cubes[cubeTransform].gameObject;
            go.SetActive(true);

            go.GetComponent<MeshRenderer>().material.color = Color.green;
        }
    }
}