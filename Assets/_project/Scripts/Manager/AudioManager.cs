using System;
using UnityEngine;

namespace _project.Scripts.Manager
{
    public class AudioManager : MonoBehaviour
    {
        [SerializeField] private AudioSource _oneshotAudioSource;
        private static AudioManager Instance { get; set; }

        private void Awake()
        {
            Instance ??= this;
        }


        public static void PlayClip(AudioClip clip)
        {
            Instance._oneshotAudioSource.PlayOneShot(clip);
        }
    }
}
