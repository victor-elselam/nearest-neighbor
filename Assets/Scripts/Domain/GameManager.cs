using Elselam.GameElements;
using Elselam.Pooling;
using Elselam.UI;
using UnityEngine;

namespace Elselam.Domain {
    public class GameManager : MonoBehaviour {
        private PoolManager<FindNearestNeighbor> nearestNeighborPool;
        private GameConfigs gameConfigs;
        
        [SerializeField] private int startPoolSize = 10;
        [SerializeField] private SpawnControlHud spawnControlHud;
        
        private void Start() {
            gameConfigs = Context.Instance.GameConfigs;
            var nearestNeighborPrefab = gameConfigs.NearestNeighbor;

            nearestNeighborPool = Context.Instance.PoolCreator.Create(nearestNeighborPrefab, startPoolSize);
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

        private void OnDrawGizmos() {
            if (!gameConfigs) return;
            
            Gizmos.color = Color.green;
            Gizmos.DrawWireCube(Vector3.zero, new Vector3(
                gameConfigs.PositionBounds.X * 2, 
                gameConfigs.PositionBounds.Y * 2, 
                gameConfigs.PositionBounds.Z * 2));
        }
    }
}
