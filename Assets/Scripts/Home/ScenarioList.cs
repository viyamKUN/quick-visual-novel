using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Home
{
    public class ScenarioList : MonoBehaviour
    {
        [SerializeField]
        private GameObject _buttonsContainer;
        private ScenarioButton[] _scenarioButtons;

        public void Init()
        {
            _scenarioButtons = _buttonsContainer.GetComponentsInChildren<ScenarioButton>();
            foreach (var btn in _scenarioButtons)
            {
                bool isActive = true;
                string scenarioName = $"시나리오 이름";
                btn.SetActive(isActive);
                btn.SetData(scenarioName);
            }
        }
    }
}
