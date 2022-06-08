using System.Collections.Generic;
using UnityEngine;

namespace QVN.Story
{
    public enum FEELING
    {
        IDLE, TALK, SMILE, ANGRY, SAD, HURT, TIRED
    }

    public class StroyAssets : MonoBehaviour
    {
        [SerializeField]
        private List<StandingAssetSet> _standingAssets;
        [SerializeField]
        private List<BackgroundAsset> _backgroundAssets;

        public Sprite GetStandingAsset(string name, FEELING feeling)
        {
            var id = Data.NameStaticData.GetCharacterNameData().GetID(name);
            var standings = _standingAssets.Find(x => x.ID.Equals(id)).standingSprites;
            return standings?.Find(x => x.feeling == feeling).standingSprite;
        }

        public Sprite GetBackgroundAsset(string id)
        {
            return _backgroundAssets.Find(x => x.ID.Equals(id)).backgroundSprite;
        }
    }

    [System.Serializable]
    public struct StandingAssetSet
    {
        public string ID;
        public List<StandingAsset> standingSprites;
    }

    [System.Serializable]
    public struct StandingAsset
    {
        public FEELING feeling;
        public Sprite standingSprite;
    }

    [System.Serializable]
    public struct BackgroundAsset
    {
        public string ID;
        public Sprite backgroundSprite;
    }
}
