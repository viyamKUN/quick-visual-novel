using System.Collections.Generic;
using UnityEngine;
using System.Linq;

namespace QVN.Data
{
    public static class CharacterStaticData
    {
        private static string _scenarioPath = "Characters";
        private static List<MultiLanguageString> _characterNames;

        public static void ReadData()
        {
            if (_characterNames != null) return;
            _characterNames = JsonUtility.FromJson<CharacterNames>(Resources.Load<TextAsset>(_scenarioPath).text).Names.ToList();
        }

        public static string GetID(string name)
        {
            return _characterNames.Find(x => x.KR.Equals(name) || x.EN.Equals(name) || x.JP.Equals(name)).ID;
        }
    }

    [System.Serializable]
    public class CharacterNames
    {
        public MultiLanguageString[] Names;
    }

    [System.Serializable]
    public class MultiLanguageString
    {
        public string ID;
        public string KR;
        public string EN;
        public string JP;
    }
}
