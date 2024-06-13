using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UltimateXR.Manipulation;
using UltimateXR.Avatar;
using UltimateXR.Core;
using UltimateXR.Devices;
using UltimateXR.Haptics;

public class Extinguisher1 : MonoBehaviour
{
    [SerializeField] ParticleSystem _particleSystem;
    [SerializeField] Collider _collider;
    private UxrGrabbableObject _grabbableObject;
    public bool colliderEnabled = true;
    private bool isBeingGrabbed = false;
    public bool isPressed  = false;

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
        isBeingGrabbed = UxrGrabManager.Instance.IsBeingGrabbed(_grabbableObject);
        if (isBeingGrabbed)
        {
            if (UxrGrabManager.Instance.GetGrabbingHand(_grabbableObject, 0, out UxrGrabber grabber))
            {
                if (UxrAvatar.LocalAvatarInput.GetButtonsPressDown(grabber.Side, UxrInputButtons.Trigger))
                {
                    isPressed = true;
                    _particleSystem.Play();
                    Debug.Log("Trigger pressed, particle system started");
                }

                // if (isPressed)
                // {
                //     UxrAvatar.LocalAvatar.ControllerInput.SendGrabbableHapticFeedback(_grabbableObject, UxrHapticClipType.RumbleFreqNormal);
                //     _collider.enabled = true;
                //     if (_collider.enabled)
                //         Debug.Log("Collider enabled");
                //     else
                //         Debug.Log("Collider not enabled");
                // }

                if (UxrAvatar.LocalAvatarInput.GetButtonsPressUp(grabber.Side, UxrInputButtons.Trigger))
                {
                    isPressed = false;
                    _particleSystem.Stop();
                    Debug.Log("Trigger released, particle system stopped");
                }
            }
        }
        if (isPressed)
        {
            UxrAvatar.LocalAvatar.ControllerInput.SendGrabbableHapticFeedback(_grabbableObject, UxrHapticClipType.RumbleFreqNormal);
            _collider.enabled = true;
            if (_collider.enabled)
                Debug.Log("Collider enabled");
            else
                Debug.Log("Collider not enabled");
        }
        else
        {
            _collider.enabled = false;
        }
    }
}
