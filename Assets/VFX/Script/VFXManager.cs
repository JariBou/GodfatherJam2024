using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VFXManager : MonoBehaviour
{
    [SerializeField] private ParticleSystem _scoringParticleSystem;
    [SerializeField] private ParticleSystem _appearParticleSystem;
    private ParticleSystemStopBehavior _particleSystemStopBehavior = ParticleSystemStopBehavior.StopEmitting;

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
