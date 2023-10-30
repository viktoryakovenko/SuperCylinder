using UnityEngine;

public static class DestroyExtension
{
    public static void DestroyChildren(this GameObject gameObject)
    {
        foreach (Transform child in gameObject.transform) 
        {
            Object.Destroy(child.gameObject);
        }
    }
}