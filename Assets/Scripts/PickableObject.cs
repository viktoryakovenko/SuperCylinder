using UnityEngine;


[RequireComponent(typeof(Rigidbody))]
public class PickableObject: MonoBehaviour
{
    public void PickUp(Transform parent)
    {
        PerformRigidbody(false, 10, RigidbodyConstraints.FreezeRotation, parent);
    }

    public void Drop()
    {
        PerformRigidbody(true, 1, RigidbodyConstraints.None, null);
    }

    private void PerformRigidbody(bool useGravity, int drag, RigidbodyConstraints constraints, Transform parent)
    {
        var rigidbody = gameObject.GetComponent<Rigidbody>();
        rigidbody.useGravity = useGravity;
        rigidbody.drag = drag;
        rigidbody.constraints = constraints;

        rigidbody.transform.parent = parent;
    }
}
