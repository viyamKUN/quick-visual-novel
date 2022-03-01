using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

namespace Story
{
    public class StroyAssets : MonoBehaviour
    {
        [SerializeField]
        private List<StandingAsset> _standingAssets;

        public Sprite GetStandingAsset(string name)
        {
            return _standingAssets.Find(x => x.Name.Equals(name)).StandingSprite;
        }
    }

    [System.Serializable]
    public struct StandingAsset
    {
        public string Name;
        public Sprite StandingSprite;
    }
}
