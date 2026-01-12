using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.InputSystem;
using System;
public class ThrowingAnimation : MonoBehaviour
{
    Animation anim;
    public bool isGrabbing;
    public bool isThrown;
    [SerializeField] private ActionBasedController controller;

    public GameObject Ball;
    public GameObject Hand;
    public float oldPos;
    public float newPos;


    private void Start()
    {

        
        anim = GetComponent<Animation>();

        controller.selectAction.action.started += Grab;
        controller.selectAction.action.canceled += Release;
    }
    private void Update()
    {
        
       if (isGrabbing == true && Ball.transform.position.z - Hand.transform.position.z < 0.15)
        {
            anim.enabled = false;
        }
       if (isGrabbing == false && Ball.transform.position.z - Hand.transform.position.z >= 0.15 && oldPos - newPos > 0.15)
        {
            anim.enabled = true;
        }
      
    }

    private IEnumerator CheckThrown()
    {
        oldPos = Hand.transform.position.z;
        yield return new WaitForSeconds(0.3f);
        newPos = Hand.transform.position.z;

    }
    public void Grab(InputAction.CallbackContext context)
    {
        isGrabbing = true;
    }

    public void Release(InputAction.CallbackContext context)
    {
        isGrabbing = false;
    }
}

