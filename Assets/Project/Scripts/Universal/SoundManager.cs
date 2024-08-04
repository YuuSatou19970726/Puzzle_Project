using UnityEngine;

namespace Connect.Core
{
    public class SoundManager : MonoBehaviour
    {
        public static SoundManager Instance;
        [SerializeField]
        private AudioSource _effectSource;

        void Awake()
        {
            if (Instance == null)
            {
                Instance = this;
                DontDestroyOnLoad(gameObject);
                return;
            }
            else
            {
                Destroy(gameObject);
            }
        }

        public void PlaySound(AudioClip clip)
        {
            _effectSource.PlayOneShot(clip);
        }
    }
}
