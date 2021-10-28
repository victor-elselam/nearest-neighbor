using Elselam.Pool;
using UnityEngine;

namespace Elselam {
    public class Context {
        //Don't like singletons, but a Dependency Injection for this project would be over engineering
        public static Context Instance;

        public GameConfigs GameConfigs;
        public GameManager GameManager;
        public LineRendererHelper LineRenderer;
        public PoolCreator PoolCreator;

        public Context() {
            Instance = this;
            
            GameConfigs = Resources.Load<GameConfigs>("GameConfigs");
            LineRenderer = new LineRendererHelper(GameConfigs.LineRenderer);
            PoolCreator = new PoolCreator();
            GameManager = Object.Instantiate(Resources.Load<GameManager>("GameManager"));
        }
    }
}