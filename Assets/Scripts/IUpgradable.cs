using System.Collections.Generic;

public interface IUpgradable<T> where T: IPickable
{
    IReadOnlyList<T> BodyKits { get; }

    void AddKit(T kit);
    void RemoveKit(T kit);
}