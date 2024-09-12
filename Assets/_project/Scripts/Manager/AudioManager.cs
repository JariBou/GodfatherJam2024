using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Random = UnityEngine.Random;

namespace _project.Scripts.Manager
{
    public class AudioManager : MonoBehaviour
    {
        [SerializeField] private AudioSource _oneshotAudioSource;
        private static AudioManager Instance { get; set; }
        private Fifo<AudioClip> _lastPlayedClips = new(2);

        private void Awake()
        {
            Instance ??= this;
        }


        public static void PlayClip(AudioClip clip)
        {
            Instance._oneshotAudioSource.PlayOneShot(clip);
        }
        
        public static void PlayRandomClip(List<AudioClip> clips)
        {
            Instance._oneshotAudioSource.PlayOneShot(clips[Random.Range(0, clips.Count)]);
        }
        
        public static void PlayRandomClipWithNoRepeat(List<AudioClip> clips)
        {
            AudioClip randomClip = clips[Random.Range(0, clips.Count)];
            int overflowProtection = 0;
            while (Instance._lastPlayedClips.Contains(randomClip))
            {
                if (overflowProtection > 20) return;
                randomClip = clips[Random.Range(0, clips.Count)];
                overflowProtection++;
            }
            Instance._oneshotAudioSource.PlayOneShot(randomClip);
            Instance._lastPlayedClips.Add(randomClip);
        }
    }
    
    public class Fifo<T>
    {
        private T[] _internalArray;
        private int _size;

        public Fifo(int size)
        {
            _size = size;
            _internalArray = new T[size];
        }

        public void Add(T val)
        {
            for (int i = 1; i < _size; i++)
            {
                _internalArray[i - 1] = _internalArray[i];
            }

            _internalArray[_size - 1] = val;
        }

        public bool Contains(T test)
        {
            return _internalArray.Contains(test);
        }
        
    } 
}
