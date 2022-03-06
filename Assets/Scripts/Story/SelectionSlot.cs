using UnityEngine;
using UnityEngine.UI;
using TMPro;

namespace QVN.Story
{
    public class SelectionSlot : MonoBehaviour
    {
        [SerializeField]
        private Button _button;
        [SerializeField]
        private TextMeshProUGUI _text;
        private int _id;

        public void SetSlot(int id, System.Action<int> clickAction)
        {
            _id = id;
            _button.onClick.AddListener(() => clickAction(_id));
        }

        public void ShowSlot(string message)
        {
            this.gameObject.SetActive(true);
            _text.text = message.Replace("{n}", Data.PlayerSaveData.Name);
        }

        public void OffSlot()
        {
            this.gameObject.SetActive(false);
        }
    }
}
