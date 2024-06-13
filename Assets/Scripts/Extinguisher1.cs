using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UltimateXR.Manipulation;
using UltimateXR.Avatar;
using UltimateXR.Devices;
using UltimateXR.Core;
using UltimateXR.Haptics;

public class Extinguisher1 : MonoBehaviour
{
    [SerializeField] ParticleSystem _particleSystem;
    [SerializeField] Collider _collider;
    private UxrGrabbableObject _grabbableObject;
    public bool colliderEnabled = false;
    private bool isBeingGrabbed = false;
    public bool isPressed = false;

    private void Awake()
    {
        _grabbableObject = GetComponent<UxrGrabbableObject>();

        if (_particleSystem == null)
        {
            _particleSystem = GetComponent<ParticleSystem>();
        }
        if (_collider == null)
        {
            _collider = GetComponent<Collider>();
        }
        if (_collider != null)
        {
            _collider.enabled = colliderEnabled;
        }

        Debug.Log("Particle system initialized");
    }

    private void Update()
    {
        // Check if the object is being grabbed
        isBeingGrabbed = UxrGrabManager.Instance.IsBeingGrabbed(_grabbableObject);

        if (isBeingGrabbed)
        {
            // Handle input when the object is grabbed
            if (UxrGrabManager.Instance.GetGrabbingHand(_grabbableObject, 0, out UxrGrabber grabber))
            {
                if (UxrAvatar.LocalAvatarInput.GetButtonsPressDown(grabber.Side, UxrInputButtons.Trigger))
                {
                    isPressed = true;
                    _particleSystem.Play();
                    _collider.enabled = true;
                    if (_collider.enabled && _particleSystem.isPlaying)
                    {
                        Debug.Log("Trigger pressed, particle system started, collider enabled");
                    }
                }

                if (UxrAvatar.LocalAvatarInput.GetButtonsPressUp(grabber.Side, UxrInputButtons.Trigger))
                {
                    isPressed = false;
                    _particleSystem.Stop();
                    _collider.enabled = false;
                    if (!_collider.enabled && !_particleSystem.isPlaying)
                    {
                        Debug.Log("Trigger released, particle system stopped, collider disabled");
                    }
                }
            }
        }
        else if (_collider.enabled || _particleSystem.isPlaying)
        {
            // Ensure the collider and particle system are disabled when the object is not grabbed
            _particleSystem.Stop();
            _collider.enabled = false;
            Debug.Log("Extinguisher not grabbed, particle system stopped, collider disabled");
        }
    }
}
