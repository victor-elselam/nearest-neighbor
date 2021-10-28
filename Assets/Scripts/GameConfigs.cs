using Elselam.GameElements;
using UnityEngine;

namespace Elselam {
    [CreateAssetMenu(menuName = "Create GameConfigs", fileName = "GameConfigs", order = 0)]
    public class GameConfigs : ScriptableObject {
        [SerializeField] [Range(0, 10)] private float cubeSpeed = 5f;
        public float CubeSpeed => cubeSpeed;
        
        [SerializeField] private LineRenderer lineRendererPrefab;
        public LineRenderer LineRenderer => lineRendererPrefab;
        
        [SerializeField] private FindNearestNeighbor nearestNeighborPrefab;
        public FindNearestNeighbor NearestNeighbor => nearestNeighborPrefab;

        [SerializeField] private PositionBounds positionBounds;
        public PositionBounds PositionBounds => positionBounds;
        
        [Space(10)]
        
        [SerializeField] private KeyCode addItemKey;
        public KeyCode AddItemKey => addItemKey;
        
        [SerializeField] private KeyCode removeItemKey;
        public KeyCode RemoveItemKey => removeItemKey;
    }
}
