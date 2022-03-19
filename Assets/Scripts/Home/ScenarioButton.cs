using UnityEngine;
using TMPro;

namespace Home
{
    public class ScenarioButton : MonoBehaviour
    {
        [SerializeField]
        private TextMeshProUGUI _scenarioName;

        public void SetData(string scenarioName)
        {
            _scenarioName.text = scenarioName;
        }

        public void SetActive(bool isActive)
        {
            gameObject.SetActive(isActive);
        }
    }
}
