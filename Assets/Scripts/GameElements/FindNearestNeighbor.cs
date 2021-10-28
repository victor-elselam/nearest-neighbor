using System.Collections.Generic;
using System.Linq;
using Elselam.Domain;
using Elselam.Pooling;
using UnityEngine;

namespace Elselam.GameElements {
    public class FindNearestNeighbor : MonoBehaviour, IPoolable<FindNearestNeighbor> {
        private List<FindNearestNeighbor> neighbors;
        private LineRenderer lineRenderer;
        
        private void Start() {
            lineRenderer = Context.Instance.LineRenderer.Create(Vector3.zero, Vector3.zero, Extensions.RandomColor);
            lineRenderer.gameObject.SetActive(false);
        }

        public void Update() {
            if (neighbors.IsNullOrEmpty()) {
                return;
            }

            //we need to make a copy to ensure we won't mess our for loop if another instance is added while iterating
            var listForIteration = neighbors.ToList();;
            FindNearestNeighbor nearest = null;
            var closestDistance = float.MaxValue;
            
            for (var i = 0; i < listForIteration.Count; i++) {
                var currentNeighbor = listForIteration[i];
                var distance = Vector3.Distance(transform.position, currentNeighbor.transform.position);
                if (distance < closestDistance && currentNeighbor != this) {
                    nearest = currentNeighbor;
                    closestDistance = distance;
                }
            }
            
            if (nearest) {
                UpdateLine(nearest.transform.position);
            }
        }

        private void UpdateLine(Vector3 target) {
            if (!lineRenderer) {
                return;
            }
            if (!lineRenderer.gameObject.activeInHierarchy) {
                lineRenderer.gameObject.SetActive(true);
            }

            lineRenderer.SetPositions(new []{transform.position, target});
        }

        #region Interface
        public void Setup(ref List<FindNearestNeighbor> neighbors) {
            this.neighbors = neighbors;
        }

        public FindNearestNeighbor Create(ref List<FindNearestNeighbor> neighbors) {
            var position = Extensions.RandomPosition(Context.Instance.GameConfigs.PositionBounds);
            var newGameObject = Instantiate(this, position, Quaternion.identity);
            newGameObject.Setup(ref neighbors);
            return newGameObject;
        }
        
        public void Remove() {
            Destroy(gameObject);
            Destroy(lineRenderer.gameObject);
        }
        #endregion
    }
}
