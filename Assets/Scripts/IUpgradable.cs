using System.Collections.Generic;
using UnityEngine;

public interface IUpgradable
{
    IReadOnlyDictionary<Transform, Collider> BodyKits { get; }

    void AddKit(Collider kit);
    void RemoveKit(Collider kit);
}