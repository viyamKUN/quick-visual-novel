using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace QVN.DefaultUI
{
    public class ButtonAnimator : MonoBehaviour
    {
        [SerializeField]
        private Image _buttonImage;
        [SerializeField]
        private EventTrigger _eventTrigger;

        public void Init(System.Action clickAction)
        {
            EventTrigger.Entry entry;

            entry = new EventTrigger.Entry();
            entry.eventID = EventTriggerType.PointerDown;
            entry.callback.AddListener(action => Down());
            _eventTrigger.triggers.Add(entry);

            entry = new EventTrigger.Entry();
            entry.eventID = EventTriggerType.PointerUp;
            entry.callback.AddListener(action => Release());
            _eventTrigger.triggers.Add(entry);

            entry = new EventTrigger.Entry();
            entry.eventID = EventTriggerType.PointerExit;
            entry.callback.AddListener(action => Release());
            _eventTrigger.triggers.Add(entry);

            entry = new EventTrigger.Entry();
            entry.eventID = EventTriggerType.PointerClick;
            entry.callback.AddListener(action => clickAction());
            _eventTrigger.triggers.Add(entry);
        }

        private void Down()
        {
            // 클릭중일때의 이벤트
        }

        private void Release()
        {
            // 클릭 해제된 이벤트
        }
    }
}
