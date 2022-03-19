using UnityEngine;
using TMPro;

namespace QVN.Home
{
    public class ScenarioButton : MonoBehaviour
    {
        [SerializeField]
        private TextMeshProUGUI _scenarioName;
        private int _scenarioID;
        private System.Action<int> _selectAction;

        public void SetData(int scenarioID, string scenarioName, System.Action<int> selectAction)
        {
            _scenarioID = scenarioID;
            _scenarioName.text = scenarioName;
            _selectAction = selectAction;
        }

        public void SetActive(bool isActive)
        {
            gameObject.SetActive(isActive);
        }

        public void SelectScenario()
        {
            Debug.Log($"{_scenarioID}번의 시나리오를 선택함.");
            _selectAction(_scenarioID);
        }
    }
}
