using System.Collections.Generic;

namespace Elselam.Pool {
    public class PoolManager<T> where T : IPoolable<T> {
        private List<T> objects;
        private readonly T itemReference;

        public int Count => objects.Count;
        
        public PoolManager(T itemReference) {
            objects = new List<T>();
            this.itemReference = itemReference;
        }

        public void AddItem(int count = 1) {
            for (var i = 0; i < count; i++) {
                objects.Add(itemReference.Create(ref objects));
            }
        }

        public void RemoveCount(int count) {
            for (var i = 0; i < count; i++) {
                RemoveAt(objects.Count - 1);
            }
        }
        
        public void RemoveAt(int index) {
            if (index >= 0 && index < objects.Count) {
                var item = objects[index];
                objects.RemoveAt(index); //remove from list
                item.Remove(); //remove from memory
            }
        }
    }
}
