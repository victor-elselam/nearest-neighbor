using UnityEngine;

namespace Elselam.Domain {
    public class AppStart : MonoBehaviour {

        private void Awake() {
            var _ = new Context();
        }
    }
}
