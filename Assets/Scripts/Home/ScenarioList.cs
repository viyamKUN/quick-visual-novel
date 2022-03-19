using UnityEngine;

namespace QVN.Home
{
    public class ScenarioList : MonoBehaviour
    {
        [SerializeField]
        private HomeManager _homeManager;
        [SerializeField]
        private GameObject _buttonsContainer;
        private ScenarioButton[] _scenarioButtons;

        public void Init()
        {
            if (_scenarioButtons == null)
            {
                _scenarioButtons = _buttonsContainer.GetComponentsInChildren<ScenarioButton>();
            }
            int index = 0;
            var scenarioIDs = Data.StoryStaticData.GetScenarioIDs;
            foreach (var btn in _scenarioButtons)
            {
                bool isActive = index < scenarioIDs.Count;
                btn.SetActive(isActive);
                if (!isActive) continue;
                var scenarioName = $"{scenarioIDs[index]}. Scenario";
                btn.SetData(index++, scenarioName, LoadSelectedScenario);
            }
        }

        private void LoadSelectedScenario(int scenarioID)
        {
            _homeManager.MoveToStoryScene(scenarioID);
        }
    }
}
