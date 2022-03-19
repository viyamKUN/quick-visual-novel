using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Home
{
    public class HomeManager : MonoBehaviour
    {
        [SerializeField]
        private ScenarioList _scenarioList;

        private void Start()
        {
            _scenarioList.Init();
        }
    }
}
