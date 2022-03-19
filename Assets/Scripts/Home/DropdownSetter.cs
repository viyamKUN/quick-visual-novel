using UnityEngine;
using TMPro;

namespace QVN.Home
{
    public class DropdownSetter : MonoBehaviour
    {
        [SerializeField]
        private TMP_Dropdown _dropdown;

        public void SetIndex(int index)
        {
            _dropdown.value = index;
        }
    }
}
