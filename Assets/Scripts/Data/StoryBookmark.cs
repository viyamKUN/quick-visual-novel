using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace QVN.Data
{
    public static class StoryBookmark
    {
        private static int _scenarioNumber = -99;
        public static void SetScenarioNumber(int number)
        {
            _scenarioNumber = number;
        }
        public static int GetScenarioNumber()
        {
            if (_scenarioNumber < -1)
            {
                Debug.Log("Not Set");
                return 0;
            }
            else
            {
                return _scenarioNumber;
            }
        }
    }
}
