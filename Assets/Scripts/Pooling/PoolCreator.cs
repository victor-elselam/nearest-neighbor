namespace Elselam.Pool {
    public class PoolCreator {

        public PoolManager<T> Create<T>(T poolObject, int startPoolSize = 10) where T : IPoolable<T>, new() {
            var poolManager = new PoolManager<T>(poolObject);
            poolManager.AddItem(startPoolSize);
            return poolManager;
        }
    }
}