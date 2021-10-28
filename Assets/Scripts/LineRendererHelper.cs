using UnityEngine;

namespace Elselam {
    public class LineRendererHelper {
        private readonly LineRenderer lineRenderer;

        public LineRendererHelper(LineRenderer lineRenderer) {
            this.lineRenderer = lineRenderer;
        }

        public LineRenderer Create(Vector3 pointA, Vector3 pointB, Color color) {
            var line = Object.Instantiate(lineRenderer);
            line.transform.position = Vector3.zero;
            line.startWidth = 2;
            line.endWidth = 2;
            
            line.SetPositions(new []{pointA, pointB});
            line.startColor = color;
            line.endColor = color;
            
            return line;
        }
    }
}
