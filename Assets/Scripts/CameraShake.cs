using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CameraShake : MonoBehaviour
{
    public Transform cameraTransform; // Referensi ke transformasi kamera
    public float defaultShakeDuration = 0.5f; // Durasi getaran kamera default
    public float defaultShakeMagnitude = 0.05f; // Besarnya getaran kamera default

    private Vector3 originalPos; // Posisi awal kamera
    private Coroutine shakeCoroutine; // Coroutine untuk getaran kamera

    void Start()
    {
        if (cameraTransform == null)
        {
            cameraTransform = Camera.main.transform;
        }
        originalPos = cameraTransform.localPosition;
    }

    public void StartShake(float duration, float magnitude)
    {
        if (shakeCoroutine != null)
        {
            StopCoroutine(shakeCoroutine);
        }
        shakeCoroutine = StartCoroutine(Shake(duration, magnitude));
    }

    IEnumerator Shake(float duration, float magnitude)
    {
        float elapsed = 0.0f;
        while (elapsed < duration)
        {
            Vector3 randomPoint = originalPos + Random.insideUnitSphere * magnitude;
            cameraTransform.localPosition = new Vector3(randomPoint.x, randomPoint.y, originalPos.z);

            elapsed += Time.deltaTime;
            yield return null;
        }
        cameraTransform.localPosition = originalPos;
    }
}