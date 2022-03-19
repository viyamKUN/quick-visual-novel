using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using DG.Tweening;

namespace QVN.Story
{
    public class SystemDialogSetter : DialogSetter
    {
        [SerializeField]
        private CanvasGroup _canvasGroup;

        public void Init()
        {
            gameObject.SetActive(false);
        }

        public override void SetDialog(string name, string dialog)
        {
            if (!gameObject.activeSelf)
            {
                gameObject.SetActive(true);
                _canvasGroup.DOFade(1f, 0.5f).From(0.4f);
            }
            base.SetDialog(name, dialog);
        }

        public void Close()
        {
            _canvasGroup.DOFade(0, 0.5f);
        }
    }
}
