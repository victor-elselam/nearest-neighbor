using System.Collections;
using Elselam.Domain;
using UnityEngine;

namespace Elselam.GameElements {
    public class RandomMover : MonoBehaviour {
        private GameConfigs configs;
        private Coroutine movingRoutine;

        private void Start() {
            configs = Context.Instance.GameConfigs;
            movingRoutine = StartCoroutine(RandomMovement());
        }

        private IEnumerator RandomMovement() {
            var target = Extensions.RandomPosition(configs.PositionBounds);

            do {
                var direction = (target - transform.position).normalized;
                var newPos = transform.position + (direction * (configs.CubeSpeed / 50));
                transform.position = newPos;
                yield return null;

            } while (GetDistance() > 2f);
            
            movingRoutine = StartCoroutine(RandomMovement());
            float GetDistance() {
                var distance = (target - transform.position).magnitude;
                return distance;
            }
        }

        private void OnDestroy() {
            StopCoroutine(movingRoutine);
        }
    }
}
