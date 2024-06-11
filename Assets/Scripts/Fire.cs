using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fire : MonoBehaviour
{
    [SerializeField, Range(0f, 1f)] private float currentIntensity = 1.0f;
    private float [] startIntensity = new float[0];

    [SerializeField] private ParticleSystem [] fireParticleSystems = new ParticleSystem[0];
    // Start is called before the first frame update

    void Start()
    {
        startIntensity = new float[fireParticleSystems.Length];

        for( int i = 0; i < fireParticleSystems.Length; i++)
        {
            startIntensity[i] = fireParticleSystems[i].emission.rateOverTime.constant;
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        ChangeIntensity();
    }    
    
    private void ChangeIntensity() 
    {
        for( int i = 0; i < fireParticleSystems.Length; i++)
        {
            var emission = fireParticleSystems[i].emission;
            emission.rateOverTime = currentIntensity * startIntensity[i];
        }
;
    }

}
