using System.Collections.Generic;

namespace Refactoring.Repositories.Interfaces;

public interface IRepository<T>
{
    void Add(T shape);
    IEnumerable<T> GetAll();
    void Reset();
}
