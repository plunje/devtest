using System.Collections.Generic;
using Refactoring.Repositories.Interfaces;

namespace Refactoring.Repositories;

public class Repository<T> : IRepository<T>
{
    private readonly List<T> _items = new();

    public void Add(T shape)
    {
        _items.Add(shape);
    }

    public IEnumerable<T> GetAll()
    {
        return _items;
    }

    public void Reset()
    {
        _items.Clear();
    }
}
