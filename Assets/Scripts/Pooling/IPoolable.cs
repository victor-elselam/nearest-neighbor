using System.Collections.Generic;

namespace Elselam.Pool {
    public interface IPoolable<T> {
        T Create(ref List<T> neighbors);
        void Remove();
        void Setup(ref List<T> neighbors);
    }
}
