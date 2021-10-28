using Elselam.GameElements;
using UnityEngine;

namespace Elselam.Domain {
    [CreateAssetMenu(menuName = "Create GameConfigs", fileName = "GameConfigs", order = 0)]
    public class GameConfigs : ScriptableObject {
        [Header("Cube Settings")]
        [SerializeField] [Range(0, 10)] private float cubeSpeed = 5f;
        public float CubeSpeed => cubeSpeed;
        
        [SerializeField] private FindNearestNeighbor nearestNeighborPrefab;
        public FindNearestNeighbor NearestNeighbor => nearestNeighborPrefab;

        [Header("Other Settings")]
        [SerializeField] private PositionBounds positionBounds;
        public PositionBounds PositionBounds => positionBounds;

        [SerializeField] private LineRenderer lineRendererPrefab;
        public LineRenderer LineRenderer => lineRendererPrefab;
        
        [SerializeField] [Range(0, 5)] private float lineRendererWidth = 1f;
        public float LineRendererWidth => lineRendererWidth;
        
        [Header("Keys Settings")]
        [Space(10)]
        
        [SerializeField] private KeyCode addItemKey;
        public KeyCode AddItemKey => addItemKey;
        
        [SerializeField] private KeyCode removeItemKey;
        public KeyCode RemoveItemKey => removeItemKey;
    }
}
