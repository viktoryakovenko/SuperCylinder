using System.Collections.Generic;

public interface IUpgradable<T> where T: PickableObject
{
    IReadOnlyList<T> BodyKits { get; }

    void AddKit(T kit);
    void RemoveKit(T kit);
}