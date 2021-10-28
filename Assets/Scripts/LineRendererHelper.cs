using UnityEngine;

namespace Elselam {
    public class LineRendererHelper {
        private readonly GameConfigs gameConfigs;

        public LineRendererHelper(GameConfigs gameConfigs) {
            this.gameConfigs = gameConfigs;
        }

        public LineRenderer Create(Vector3 pointA, Vector3 pointB, Color color) {
            var line = Object.Instantiate(gameConfigs.LineRenderer);
            line.transform.position = Vector3.zero;
            line.startWidth = gameConfigs.LineRendererWidth;
            line.endWidth = gameConfigs.LineRendererWidth;
            
            line.SetPositions(new []{pointA, pointB});
            line.startColor = color;
            line.endColor = color;
            
            return line;
        }
    }
}
