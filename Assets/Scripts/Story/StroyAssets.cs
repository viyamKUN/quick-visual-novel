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

        public Sprite GetStandingAsset(string name, FEELING feeling)
        {
            var id = Data.CharacterStaticData.GetID(name);
            var standings = _standingAssets.Find(x => x.ID.Equals(id)).StandingSprites;
            return standings?.Find(x => x.Feeling == feeling).StandingSprite;
        }
    }

    [System.Serializable]
    public struct StandingAssetSet
    {
        public string ID;
        public List<StandingAsset> StandingSprites;
    }

    [System.Serializable]
    public struct StandingAsset
    {
        public FEELING Feeling;
        public Sprite StandingSprite;
    }
}
