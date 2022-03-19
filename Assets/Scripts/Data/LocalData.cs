using UnityEngine;

namespace QVN.Data
{
    public enum LANGUAGE
    {
        KR, EN, JP
    }
    public static class LocalData
    {
        private static readonly string _languagePrefName = "Language";
        private static LANGUAGE _language = LANGUAGE.KR;

        public static void ReadLocalData()
        {
            var lan = PlayerPrefs.GetString(_languagePrefName, "KR");
            ChangeLanguage(lan);
        }

        public static void ChangeLanguage(LANGUAGE language)
        {
            ChangeLanguage(language.ToString());
        }

        public static void ChangeLanguage(string language)
        {
            switch (language)
            {
                case "KR":
                    _language = LANGUAGE.KR;
                    break;
                case "EN":
                    _language = LANGUAGE.EN;
                    break;
                case "JP":
                    _language = LANGUAGE.JP;
                    break;
            }
            PlayerPrefs.SetString(_languagePrefName, language);
            PlayerPrefs.Save();
        }

        public static LANGUAGE GetLanguage => _language;
    }
}
