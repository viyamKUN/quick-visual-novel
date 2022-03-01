using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Story
{
    public class StandingSetter : MonoBehaviour
    {
        [SerializeField]
        private StroyAssets _assets;
        [SerializeField]
        private List<Image> _standingSlots;
        private List<string> _names = new List<string>(){
            string.Empty, string.Empty, string.Empty
         };

        public void SetStandings(string contents)
        {
            if (contents.Equals(string.Empty))
            {
                SetStandingSlots(null);
            }
            SetStandingSlots(contents.Split(','));
        }

        private void SetStandingSlots(string[] members)
        {
            if (members == null)
            {
                _standingSlots.ForEach(x => x.gameObject.SetActive(false));
            }
            else if (members.Length == 1)
            {
                SetSlot(_standingSlots[0], members[0]);
                _standingSlots[1].gameObject.SetActive(false);
                _standingSlots[2].gameObject.SetActive(false);
                _names[0] = members[0];
                _names[1] = string.Empty;
                _names[2] = string.Empty;
            }
            else
            {
                _standingSlots[0].gameObject.SetActive(false);
                SetSlot(_standingSlots[1], members[0]);
                SetSlot(_standingSlots[2], members[1]);
                _names[0] = string.Empty;
                _names[1] = members[0];
                _names[2] = members[1];
            }
        }

        private void SetSlot(Image image, string name)
        {
            var sprite = _assets.GetStandingAsset(name);
            if (sprite == null)
            {
                image.gameObject.SetActive(false);
            }
            else
            {
                image.gameObject.SetActive(true);
                image.sprite = sprite;
            }
        }

        public void SetHighlight(string talker)
        {
            for (int i = 0; i < 3; i++)
            {
                _standingSlots[i].color = _names[i].Equals(talker) ? Color.white : Color.gray;
            }
        }
    }
}
