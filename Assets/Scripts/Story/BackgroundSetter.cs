using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

namespace QVN.Story
{
    public class BackgroundSetter : MonoBehaviour
    {
        [SerializeField]
        private StroyAssets _assets;
        [SerializeField]
        private Image _image;
        [SerializeField]
        private TextMeshProUGUI _nameText;

        public void UpdateImage(string id)
        {
            _image.sprite = _assets.GetBackgroundAsset(id);
            var name = Data.NameStaticData.GetBackgroundNameData().GetName(id);
            _nameText.text = name;
        }
    }
}
