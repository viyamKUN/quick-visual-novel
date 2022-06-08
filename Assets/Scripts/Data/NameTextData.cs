using System.Collections.Generic;
using UnityEngine;
using System.Linq;

namespace QVN.Data
{
    public class NameTextData
    {
        private List<MultiLanguageString> _names;

        public NameTextData(string path)
        {
            _names = JsonUtility.FromJson<MultiLanguageStringArray>(Resources.Load<TextAsset>(path).text).Names.ToList();
        }

        public string GetID(string name)
        {
            return _names.Find(x => x.KR.Equals(name) || x.EN.Equals(name) || x.JP.Equals(name)).ID;
        }

        public string GetName(string id)
        {
            var lan = Data.LocalData.GetLanguage;
            var names = _names.Find(x => x.ID.Equals(id));
            if (names is null)
            {
                Debug.LogError($"[{id}]에 해당하는 데이터가 존재하지 않습니다.");
                return string.Empty;
            }
            switch (lan)
            {
                case LANGUAGE.KR:
                    return names.KR;

                case LANGUAGE.EN:
                    return names.EN;

                case LANGUAGE.JP:
                    return names.JP;
            }
            return names.KR;
        }
    }

    [System.Serializable]
    public class MultiLanguageStringArray
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
