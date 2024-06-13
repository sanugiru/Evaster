using System.Collections;
using System.Collections.Generic;
using FernandoOleaDev.FyreSystem;
using UnityEngine;

public class fire_propagation_controller : MonoBehaviour
{
    public GameObject burnableObject;
    [SerializeField] BurnableObject burnableObjectScript;
    public Collider colliderObject;
    public Collider colliderExtinguisherWater;
    public Collider colliderExtinguisherFoam;
    public Collider colliderExtinguisherCO2;
    public Collider colliderExtinguisherPowder;
    public float extinguishPercentage = 0.1f;
    public float extinguishTime = 10f;
    public bool isExtinguishing = false;
    public bool isExtinguished = false;

    // Start is called before the first frame update
    void Start()
    {
        burnableObjectScript.flamePropagationSeconds = 10.0f;
        burnableObjectScript.combustionSeconds = 100.0f;
        burnableObjectScript.coolingSeconds = 5.0f;
    }

    // Update is called once per frame
    void Update()
    {
        if (!isExtinguished && extinguishPercentage < 1f && colliderObject && colliderExtinguisherWater && colliderObject.bounds.Intersects(colliderExtinguisherWater.bounds))
        {
            Extinguish();
        }
        else if (!isExtinguished && extinguishPercentage < 1f && colliderObject && colliderExtinguisherFoam && colliderObject.bounds.Intersects(colliderExtinguisherFoam.bounds))
        {
            Extinguish();
        }
        else if (!isExtinguished && extinguishPercentage < 1f && colliderObject && colliderExtinguisherCO2 && colliderObject.bounds.Intersects(colliderExtinguisherCO2.bounds))
        {
            Extinguish();
        }
        else if (!isExtinguished && extinguishPercentage < 1f && colliderObject && colliderExtinguisherPowder && colliderObject.bounds.Intersects(colliderExtinguisherPowder.bounds))
        {
            Extinguish();
        }
        else if (!isExtinguished && !isExtinguishing && extinguishPercentage > 0f && colliderObject && colliderExtinguisherWater && !colliderObject.bounds.Intersects(colliderExtinguisherWater.bounds))
        {
            ExtinguishPercentage();
        }
        else if (!isExtinguished && !isExtinguishing && extinguishPercentage > 0f && colliderObject && colliderExtinguisherFoam && !colliderObject.bounds.Intersects(colliderExtinguisherFoam.bounds))
        {
            ExtinguishPercentage();
        }
        else if (!isExtinguished && !isExtinguishing && extinguishPercentage > 0f && colliderObject && colliderExtinguisherCO2 && !colliderObject.bounds.Intersects(colliderExtinguisherCO2.bounds))
        {
            ExtinguishPercentage();
        }
        else if (!isExtinguished && !isExtinguishing && extinguishPercentage > 0f && colliderObject && colliderExtinguisherPowder && !colliderObject.bounds.Intersects(colliderExtinguisherPowder.bounds))
        {
            ExtinguishPercentage();
        }
        
        
    }

    void Extinguish()
    {
        isExtinguishing = true;

        float increment = Time.deltaTime / extinguishTime;
        extinguishPercentage = Mathf.Clamp01(extinguishPercentage + increment);
        if (extinguishPercentage == 1f)
        {
            isExtinguished = true;
            isExtinguishing = false;
            burnableObjectScript.flamePropagationSeconds = 0.0f;
            burnableObjectScript.combustionSeconds = 0.0f;
            burnableObjectScript.generateLight = false;
            // if (burnableObjectScript.flamePropagationSeconds == 0.2f && burnableObjectScript.combustionSeconds == 0.2f && !burnableObjectScript.generateLight)
            // {
            //     Debug.Log("Fire extinguished");
            // }
        }
    }

    void ExtinguishPercentage()
    {
        float decrement = Time.deltaTime / extinguishTime;
        extinguishPercentage = Mathf.Clamp01(extinguishPercentage - decrement);
    }
}
