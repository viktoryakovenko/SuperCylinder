using System.Collections;
using System.Collections.Generic;
using System.Linq;
using SuperCylinder;
using UnityEngine;

public class CylinderTest : MonoBehaviour
{
    [SerializeField] private List<Sphere> _spheres;
    [SerializeField] private List<Cube> _cubes;
    [SerializeField] private Cylinder _cylinderCollider;
    [SerializeField] private float _spawnRadius;

    private Cylinder _cylinder;

    private void Start() 
    {
        _cylinder = _cylinderCollider.GetComponent<Cylinder>();
        _cylinder.Init(_cubes);

        foreach (var cube in _cubes)
        {
            cube.Init(_spheres.Where(sphere => sphere.Parent == cube).ToList());
            cube.HideKits();
        }

        _cylinder.HideKits();

        SpawnKits();
    }

    private void SpawnKits()
    {
        var cubes = _cylinder.BodyKits.Values;

        ConfigureKits(cubes);

        foreach (var cube in cubes)
        {
            var spheres = cube.BodyKits.Values;
            ConfigureKits(spheres);
        }
    }

    private void ConfigureKits(IEnumerable<ChildNode> kits)
    {
        foreach (var kit in kits)
        {
            var randomX = Random.Range(-_spawnRadius, _spawnRadius);
            var randomY = Random.Range(0, _spawnRadius);
            var randomZ = Random.Range(-_spawnRadius, _spawnRadius);

            var createdKit = Instantiate(kit, new Vector3(randomX, randomY, randomZ), Quaternion.identity);
            createdKit.gameObject.SetActive(true);
            createdKit.gameObject.AddComponent<PickableObject>();

            var collider = createdKit.gameObject.GetComponent<Collider>();
            collider.isTrigger = false;

            var kitRigidbody = createdKit.gameObject.GetComponent<Rigidbody>();
            kitRigidbody.useGravity = true;
            kitRigidbody.constraints = RigidbodyConstraints.None ^ RigidbodyConstraints.FreezePositionX ^ RigidbodyConstraints.FreezePositionZ;
        }
    }
}
