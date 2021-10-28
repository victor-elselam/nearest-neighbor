using System;
using Elselam.Domain;
using UnityEngine;
using UnityEngine.UI;

namespace Elselam.UI {
    public class SpawnControlHud : MonoBehaviour {
        private GameConfigs config;
        
        [SerializeField] private InputField inputField;
        [SerializeField] private Button sum;
        [SerializeField] private Button subtract;
        [Space(10)]
        [SerializeField] private Button add;
        [SerializeField] private Button remove;
        [Space(10)] 
        [SerializeField] private Text objectsCount;

        public event Action<int> OnRemove;
        public event Action<int> OnAdd;

        private void Start() {
            config = Context.Instance.GameConfigs;
            SetInputNumber(0);
            
            sum.onClick.AddListener(() => SetInputNumber(GetInputNumber() + 1));
            subtract.onClick.AddListener(() => SetInputNumber(GetInputNumber() - 1));
            
            add.onClick.AddListener(() => OnAdd?.Invoke(GetInputNumber()));
            remove.onClick.AddListener(() => OnRemove?.Invoke(GetInputNumber()));
        }

        private void Update() {
            if (Input.GetKeyDown(config.AddItemKey)) {
                OnAdd?.Invoke(GetInputNumber());
            }
            if (Input.GetKeyDown(config.RemoveItemKey)) {
                OnRemove?.Invoke(GetInputNumber());
            }
        }

        public void UpdateItemsCount(int count) {
            objectsCount.text = $"{count} Cubes";
        }

        private void SetInputNumber(int count) => inputField.text = Mathf.Clamp(count, 0, int.MaxValue).ToString();

        private int GetInputNumber() {
            var success = int.TryParse(inputField.text, out var count);
            if (!success) {
                count = 0;
            }
            return count;
        }
    }
}
