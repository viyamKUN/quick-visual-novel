using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

namespace QVN.Data
{
    using Models;
    public static class StoryStaticData
    {
        private static string _scenarioPath = "/Scenarios";
        private static Dictionary<int, List<ScenarioLine>> _scenarios;

        public static void DeleteData()
        {
            _scenarios?.Clear();
            _scenarios = null;
        }

        public static void ReadData()
        {
            if (_scenarios != null) return;
            _scenarios = new Dictionary<int, List<ScenarioLine>>();
            var path = $"{Data.LocalData.GetLanguage}{_scenarioPath}";
            foreach (var asset in Resources.LoadAll<TextAsset>(path))
            {
                var dataList = DefaultSystem.CSVReader.Read(asset);
                var id = int.Parse(asset.name.Replace("Scenario_", ""));
                _scenarios.Add(id, new List<ScenarioLine>());
                foreach (var data in dataList)
                {
                    _scenarios[id].Add(new ScenarioLine(
                        data["Code"], data["Flag"], data["Info"], data["SubInfo"], data["SubContents"], data["Contents"]
                    ));
                }
            }
        }

        public static List<ScenarioLine> GetScenario(int scenarioNumber)
        {
            return _scenarios[scenarioNumber];
        }

        public static List<int> GetScenarioIDs => _scenarios.Keys.ToList();
    }
}
