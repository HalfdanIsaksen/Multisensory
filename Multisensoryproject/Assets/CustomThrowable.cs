using System.Collections;
using System.Collections.Generic;
using Valve.VR;
using Valve.VR.InteractionSystem;
using UnityEngine;
using System;

public class CustomThrowable : MonoBehaviour
{
    public SteamVR_Action_Single squeezeAction;
    public SteamVR_Input_Sources handType = SteamVR_Input_Sources.Any;

    public float maxForce = 10f;
    private Interactable interactable;
    private Rigidbody rb;
    private Throwable throwable;
    // Start is called before the first frame update
    void Awake()
    {
        interactable = GetComponent<Interactable>();
        rb = GetComponent<Rigidbody>();
    }

/*    private void OnEnable()
    {
        interactable.onDetachedFromHand += HandleDetachFromHand;
    }

    private void OnDisable()
    {
        interactable.onDetachedFromHand -= HandleDetachFromhand;
    }

    private void HandleDetachFromhand(Hand hand)
    {
        throw new NotImplementedException();
    }

    void HandleDetachFromHand(Hand hand)
    {
        float squeeze = squeezeAction.GetAxis(handType);

        float forceToApply = maxForce * (1 - squeeze);
        Debug.Log(forceToApply);
        Vector3 throwDirection = hand.GetTrackedObjectVelocity().normalized;
        rb.AddForce(throwDirection * forceToApply, ForceMode.VelocityChange);
    }*/
    // Update is called once per frame
    void Update()
    {
        if (interactable.attachedToHand)
        {
            float squeeze = squeezeAction.GetAxis(handType);
            float forceToApply = maxForce * (1 - squeeze);
            rb.AddForce(Vector3.down * forceToApply);
        }
    }
}
