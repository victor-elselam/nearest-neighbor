using Elselam.GameElements;
using Elselam.Pool;
using UnityEngine;

namespace Elselam {
    public class GameManager : MonoBehaviour {
        private PoolManager<FindNearestNeighbor> nearestNeighborPool;
        [SerializeField] private SpawnControlHud spawnControlHud;
        
        private void Start() {
            var nearestNeighborPrefab = Context.Instance.GameConfigs.NearestNeighbor;
            nearestNeighborPool = Context.Instance.PoolCreator.Create(nearestNeighborPrefab);
            spawnControlHud.UpdateItemsCount(nearestNeighborPool.Count);

            spawnControlHud.OnAdd += SpawnItems;
            spawnControlHud.OnRemove += RemoveItems;
        }
        
        private void OnDestroy() {
            spawnControlHud.OnAdd -= SpawnItems;
            spawnControlHud.OnRemove -= RemoveItems;
        }

        private void SpawnItems(int count) {
            nearestNeighborPool.AddItem(count);
            spawnControlHud.UpdateItemsCount(nearestNeighborPool.Count);
        }

        private void RemoveItems(int count) {
            nearestNeighborPool.RemoveCount(count);
            spawnControlHud.UpdateItemsCount(nearestNeighborPool.Count);
        }
    }
}
