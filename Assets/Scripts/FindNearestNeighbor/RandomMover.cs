using System.Collections;
using UnityEngine;

namespace Elselam.GameElements {
    public class RandomMover : MonoBehaviour {
        [SerializeField] private float speed;
        private PositionBounds bounds;
        private bool moving;

        private void Start() {
            moving = true;
            bounds = Context.Instance.GameConfigs.PositionBounds;
            StartCoroutine(RandomMovement());
        }

        private IEnumerator RandomMovement() {
            while (moving) {
                Vector3 newPosition;

                do {
                    var movement = RandomDirection * speed;
                    newPosition = transform.position + movement;
                } while (IsOutOfBounds(newPosition));
                
                transform.position = newPosition;
                yield return new WaitForSeconds(0.05f);
            }
        }

        private bool IsOutOfBounds(Vector3 position) =>
            (position.x > bounds.X || position.x < -bounds.X) ||
            (position.y > bounds.Y || position.y < -bounds.Y) ||
            (position.z > bounds.Z || position.z < -bounds.Z);

        private Vector3 RandomDirection => new Vector3(Random.Range(-1f, 1f), Random.Range(-1f, 1f), Random.Range(-1f, 1f));
    }
}
