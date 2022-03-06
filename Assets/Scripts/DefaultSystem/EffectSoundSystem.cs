using System.Collections.Generic;
using UnityEngine;

namespace QVN.DefaultSystem
{
    public class EffectSoundSystem : MonoBehaviour
    {
        private static EffectSoundSystem _instance;
        public static EffectSoundSystem GetInstance => _instance;
        [SerializeField]
        private AudioSource _audio;
        [SerializeField]
        private List<AudioClip> _clips;
        private Dictionary<string, AudioClip> _clipMap;

        private void Awake()
        {
            if (EffectSoundSystem.GetInstance == null)
            {
                _instance = this;
            }
            else
            {
                if (EffectSoundSystem.GetInstance != _instance)
                {
                    GameObject.Destroy(EffectSoundSystem.GetInstance.gameObject);
                }
            }

            if (_clipMap == null)
            {
                _clipMap = new Dictionary<string, AudioClip>();
                foreach (var clip in _clips)
                {
                    _clipMap.Add(clip.name, clip);
                }
            }
            DontDestroyOnLoad(this.gameObject);
        }

        public void PlayEffect(string name)
        {
            if (!_clipMap.ContainsKey(name))
                return;
            _audio.PlayOneShot(_clipMap[name]);
        }
    }
}
