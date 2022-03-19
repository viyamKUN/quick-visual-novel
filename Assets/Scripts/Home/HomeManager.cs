using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace QVN.Home
{
    public class HomeManager : MonoBehaviour
    {
        [SerializeField]
        private ScenarioList _scenarioList;

        private void Start()
        {
            Data.StoryStaticData.ReadData();
            _scenarioList.Init();
        }
    }
}
