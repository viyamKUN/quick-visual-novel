using System.Collections.Generic;
using UnityEngine;
using System.Linq;

namespace QVN.Story
{
    using Models;

    public class SelectionSetter : MonoBehaviour
    {
        [SerializeField]
        private StoryManager _manager;
        private List<SelectionSlot> _slots;

        public void Init()
        {
            int index = 0;
            _slots = gameObject.GetComponentsInChildren<SelectionSlot>().ToList();
            _slots.ForEach(x =>
            {
                x.SetSlot(id: index++, clickAction: MakeDecision);
                x.gameObject.SetActive(false);
            });
            this.gameObject.SetActive(false);
        }

        public void SetSelections(List<ScenarioLine> selections)
        {
            this.gameObject.SetActive(true);
            int index = 0;
            _slots.ForEach(x =>
            {
                if (index < selections.Count)
                {
                    x.ShowSlot(selections[index].Contents);
                }
                else
                {
                    x.OffSlot();
                }
                index++;
            });
        }

        public void MakeDecision(int id)
        {
            _manager.GetSelect(id);
            this.gameObject.SetActive(false);
        }
    }
}
