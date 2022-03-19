using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace QVN.Data
{
    public static class StoryBookmark
    {
        private static int _scenarioID = -99;
        public static void SetScenarioID(int number)
        {
            _scenarioID = number;
        }
        public static int GetScenarioID()
        {
            if (_scenarioID < -1)
            {
                Debug.Log("Not Set");
                return 0;
            }
            else
            {
                return _scenarioID;
            }
        }
    }
}
