using System.Collections;
using UnityEngine;
using TMPro;
using DG.Tweening;

namespace QVN.Story
{
    public class DialogSetter : MonoBehaviour
    {
        [SerializeField]
        private float _dialogShowingSpeed;
        [SerializeField]
        private TextMeshProUGUI _name;
        [SerializeField]
        private TextMeshProUGUI _dialog;
        private object _dialogAnimation;
        private Coroutine _keyboardSound;

        public void SetDialog(string name, string dialog)
        {
            _name.text = name;
            dialog = dialog.Replace("{n}", Data.PlayerSaveData.Name);
            float duration = dialog.Length * 0.1f;
            _dialogAnimation = _dialog.DOText(dialog, duration).From("").SetEase(Ease.Linear).target;
            PlayKeyboardSound(duration);
        }

        public void SetRadioDialog(string name, string dialog)
        {
            // TODO: 글씨체를 라디오문체로 변경하고 라디오 효과를 줍니다.
            _name.text = name;
            dialog = dialog.Replace("{n}", Data.PlayerSaveData.Name);
            float duration = dialog.Length * 0.1f;
            _dialogAnimation = _dialog.DOText(dialog, duration).From("").SetEase(Ease.Linear).target;
            PlayKeyboardSound(duration);
        }

        public bool IsAnimationPlaying()
        {
            if (_dialogAnimation == null)
            {
                return false;
            }
            return DOTween.IsTweening(_dialogAnimation);
        }

        public void ForceCompleteAnimation()
        {
            if (_dialogAnimation == null)
            {
                return;
            }
            DOTween.Kill(_dialogAnimation, true);
            if (_keyboardSound != null)
            {
                StopCoroutine(_keyboardSound);
            }
        }

        private void PlayKeyboardSound(float duration)
        {
            if (_keyboardSound != null)
            {
                StopCoroutine(_keyboardSound);
            }
            _keyboardSound = StartCoroutine(KeyboardSoundCoroutine(0.1f, duration));
        }

        private IEnumerator KeyboardSoundCoroutine(float term, float duration)
        {
            WaitForSeconds wait = new WaitForSeconds(term);
            float timeBucket = Time.time;

            while (Time.time - timeBucket < duration)
            {
                DefaultSystem.EffectSoundSystem.GetInstance?.PlayEffect("keyboard");
                yield return wait;
            }
        }
    }
}
