using Elselam.Pool;
using UnityEngine;

namespace Elselam {
    public class Context {
        //Don't like singletons, but a Dependency Injection for this project would be over engineering
        public static Context Instance;

        public GameConfigs GameConfigs;
        public LineRendererHelper LineRenderer;
        public PoolCreator PoolCreator;
        public GameManager GameManager;

        public Context() {
            Instance = this;
            
            GameConfigs = Resources.Load<GameConfigs>("GameConfigs");
            LineRenderer = new LineRendererHelper(GameConfigs);
            PoolCreator = new PoolCreator();
            GameManager = Object.Instantiate(Resources.Load<GameManager>("GameManager"));
        }
    }
}
