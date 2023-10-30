using System.Collections.Generic;
using SuperCylinder;
using UnityEngine;

public class CylinderTest : MonoBehaviour
{
    [SerializeField] private Cylinder _cylinderCollider;
    [SerializeField] private float _spawnRadius;

    private Cylinder _cylinder;

    private void Start() 
    {
        _cylinder = _cylinderCollider.GetComponent<Cylinder>();

        SpawnKits();
        HideKits();
    }

    private void SpawnKits()
    {
        var cubes = _cylinder.BodyKits.Values;

        ConfigureKits(cubes);

        foreach (var cube in cubes)
        {
            var spheres = cube.GetComponent<Cube>().BodyKits.Values;
            ConfigureKits(spheres);
        }
    }

    private void HideKits()
    {
        _cylinder.HideKits();

        var cubes = _cylinder.BodyKits.Values;

        foreach (var cube in cubes)
        {
            cube.GetComponent<Cube>().HideKits();
        }
    }

    private void ConfigureKits(IEnumerable<Collider> kits)
    {
        foreach (var kit in kits)
        {
            var randomX = Random.Range(-_spawnRadius, _spawnRadius);
            var randomY = Random.Range(0, _spawnRadius);
            var randomZ = Random.Range(-_spawnRadius, _spawnRadius);

            var createdKit = Instantiate(kit, new Vector3(randomX, randomY, randomZ), Quaternion.identity);
            createdKit.gameObject.SetActive(true);
            createdKit.gameObject.DestroyChildren();

            createdKit.gameObject.AddComponent<PickableObject>();

            var collider = createdKit.gameObject.GetComponent<Collider>();
            collider.isTrigger = false;

            var kitRigidbody = createdKit.gameObject.AddComponent<Rigidbody>();
            kitRigidbody.useGravity = true;
            kitRigidbody.constraints = RigidbodyConstraints.FreezeAll ^ RigidbodyConstraints.FreezePositionY;
        }
    }
}
