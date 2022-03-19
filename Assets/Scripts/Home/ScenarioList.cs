using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace QVN.Home
{
    public class ScenarioList : MonoBehaviour
    {
        [SerializeField]
        private GameObject _buttonsContainer;
        [SerializeField]
        private DefaultUI.SceneLoader _sceneLoader;

        private ScenarioButton[] _scenarioButtons;

        public void Init()
        {
            _scenarioButtons = _buttonsContainer.GetComponentsInChildren<ScenarioButton>();
            int index = 0;
            var scenarioIDs = Data.StoryStaticData.GetScenarioIDs;
            foreach (var btn in _scenarioButtons)
            {
                bool isActive = index < scenarioIDs.Count;
                btn.SetActive(isActive);
                if (!isActive) continue;
                var scenarioName = $"{scenarioIDs[index]}. 시나리오 이름";
                btn.SetData(index++, scenarioName, LoadSelectedScenario);
            }
        }

        private void LoadSelectedScenario(int scenarioID)
        {
            Data.StoryBookmark.SetScenarioID(scenarioID);
            _sceneLoader.Load(DefaultUI.SceneName.Story);
        }
    }
}
