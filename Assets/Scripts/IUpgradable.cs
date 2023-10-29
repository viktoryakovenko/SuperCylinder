using System.Collections.Generic;
using SuperCylinder;
using UnityEngine;

public interface IUpgradable<T> where T : ChildNode
{
    IReadOnlyDictionary<Transform, T> BodyKits { get; }

    void AddKit(T kit);
    void RemoveKit(T kit);
}