using System.Collections;
using System.Collections.Generic;
using Microsoft.Unity.VisualStudio.Editor;
using UnityEngine;
using Unity.UI;
using Image = UnityEngine.UI.Image;

public class VFXManager : MonoBehaviour
{
    [SerializeField] private ParticleSystem _scoringParticleSystem;
    [SerializeField] private ParticleSystem _appearParticleSystem;
    private ParticleSystemStopBehavior _particleSystemStopBehavior = ParticleSystemStopBehavior.StopEmitting;
    [SerializeField] private Image _slider;

    public void UpdateSlider(float percent)
    {
        _slider.material.SetFloat("_SliderPercentage", percent);
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
