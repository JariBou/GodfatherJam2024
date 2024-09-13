using UnityEngine;
using Image = UnityEngine.UI.Image;

namespace VFX.Script
{
    public class VFXManager : MonoBehaviour
    {
        [SerializeField] private ParticleSystem _scoringParticleSystem;
        [SerializeField] private ParticleSystem _appearParticleSystem;
        private ParticleSystemStopBehavior _particleSystemStopBehavior = ParticleSystemStopBehavior.StopEmitting;
        [SerializeField] private Image _slider;

        public void UpdateSlider(float percent, bool playerWinning)
        {
            _slider.material.SetFloat("_SliderPercentage", percent);
            Debug.Log(playerWinning ? 1 : 0);
            _slider.material.SetInt("_IsPlayerWinning", playerWinning ? 1 : 0);
        }

        void ScoringParticleParticlePlay()
        {
            _scoringParticleSystem.Play();
        }

        void ScoringParticleParticleEnd()
        {
            _scoringParticleSystem.Stop(true, _particleSystemStopBehavior);
        }

        void AppearParticleSystemPlay()
        {
            _appearParticleSystem.Play();
        }
    
        void AppearParticleSystemEnd()
        {
            _appearParticleSystem.Stop(true, _particleSystemStopBehavior);
        }
    
    }
}
