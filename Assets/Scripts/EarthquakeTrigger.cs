using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EarthquakeTrigger : MonoBehaviour
{
    public Earthquake earthquakeScript; // Referensi ke skrip Earthquake

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("OnTriggerEnter called with: " + other.gameObject.name);

        if (other.CompareTag("Player"))
        {
            Debug.Log("player entered the trigger");

            // Aktifkan gempa
            if (earthquakeScript != null)
            {
                Debug.Log("Starting earthquake corouine");
                StartCoroutine(earthquakeScript.StartEarthquake());
            }
            else{
                Debug.LogError("earthquakeScript is not assigned");
            }
                
        }
    }
}
