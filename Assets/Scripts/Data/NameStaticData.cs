using System.Collections.Generic;
using UnityEngine;
using System.Linq;

namespace QVN.Data
{
    public static class NameStaticData
    {
        private const string _CHARACTER_FILE_NAME = "Characters";
        private const string _BG_FILE_NAME = "Backgrounds";
        private static NameTextData _characterNames;
        private static NameTextData _backgroundNames;

        public static void ReadData()
        {
            if (_backgroundNames != null && _characterNames != null) return;

            _characterNames = new NameTextData(_CHARACTER_FILE_NAME);
            _backgroundNames = new NameTextData(_BG_FILE_NAME);
        }

        public static NameTextData GetCharacterNameData()
        {
            return _characterNames;
        }

        public static NameTextData GetBackgroundNameData()
        {
            return _backgroundNames;
        }
    }
}
