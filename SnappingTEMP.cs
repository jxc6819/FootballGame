using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.XR.Interaction.Toolkit;
public class SnappingTEMP : MonoBehaviour
{
    [SerializeField] private ActionBasedController controller;


    public Autohand.Hand RightHand;
    
    public Autohand.Grabbable Box;
    public GameObject ball;
    public Rigidbody HandRigidBody;
    public FieldManager2 FM;
    public Autohand.Hand LeftHand;
    public bool Caught;
    public bool CheckSpeed;
    private void Start()
    {
        controller.selectAction.action.started += Grab;
        controller.selectAction.action.canceled += Release;

        //Debug.Log("Pos " + RightHand.followPositionStrength);
        //Debug.Log("rot " + RightHand.followRotationStrength);
        RightHand.followPositionStrength = 900;
        RightHand.followRotationStrength = 300;
        HandRigidBody.drag = 60;
        HandRigidBody.angularDrag = 60;
        RightHand.maxVelocity = 40;

    }

    private void Update()
    {
        if (Caught)
        {
            ball.SetActive(false);
         //   Debug.Log("SnappingTEMP Caught");
        }

        if(FM.Scrambling)
        {
            RightHand.maxFollowDistance = 0.7f;
          
        }
        else
        {
            RightHand.maxFollowDistance = 1;
           
        }

       
    }


    void Grab(InputAction.CallbackContext context)
    {
        if (FM.SnapLocked == false)
        {
            ball.SetActive(true);
            LeftHand.TryGrab(Box);
            RightHand.TryGrab(Box);
        }
        
    }
    void Release(InputAction.CallbackContext context)
    {

    }
}
