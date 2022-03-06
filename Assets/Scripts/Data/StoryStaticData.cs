using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace QVN.Data
{
    using Models.Story;
    public static class StoryStaticData
    {
        private static readonly string _scenarioPath = "KR/Scenarios";
        private static Dictionary<int, List<ScenarioLine>> _scenarios;

        public static void ReadData()
        {
            if (_scenarios != null) return;
            _scenarios = new Dictionary<int, List<ScenarioLine>>();

            foreach (var asset in Resources.LoadAll<TextAsset>(_scenarioPath))
            {
                var dataList = DefaultSystem.CSVReader.Read(asset);
                var id = int.Parse(asset.name.Replace("Scenario_", ""));
                _scenarios.Add(id, new List<ScenarioLine>());
                foreach (var data in dataList)
                {
                    _scenarios[id].Add(new ScenarioLine(
                        data["Code"], data["Flag"], data["Info"], data["Contents"]
                    ));
                }
            }
        }

        public static int ScenarioCount => _scenarios.Count;
        public static List<ScenarioLine> GetScenario(int scenarioNumber)
        {
            return _scenarios[scenarioNumber];
        }
    }
}
