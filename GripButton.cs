using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.XR.Interaction.Toolkit;
public class GripButton : MonoBehaviour
{
    [SerializeField] private ActionBasedController controller;
    public bool isGrabbing;
    
   public GameObject Football;
    public GameObject Hand;
    public FieldManager2 FieldManager;
    public bool StartPlay;
    public bool GiveMeDaBall;
    
    // Start is called before the first frame update
    void Start()
    {
        controller.selectAction.action.started += Grab;
        controller.selectAction.action.canceled += Release;

    }

    // Update is called once per frame
    void Update()
    {
       
        //
        //if (isGrabbing == true)
        //{
        //    FieldManager.PrePlay = false;
            
        //    StartPlay = true;
            
        //}

        if(StartPlay == true)
        {
            
            
           
            FieldManager.PrePlay = false;
            StartPlay = false;
        }
       
        


        if (isGrabbing == true)
        {
            holdDuration += Time.deltaTime;
          //  Football.transform.position = Hand.transform.position;
        }
        
        if(holdDuration > 0 && holdDuration < 1)
        {
            StartPlay = true;
        }
        
        if(isGrabbing == false)
        {
            holdDuration = 0;
            
        }

        

        
        
    }


    public float holdDuration;
    public void Grab(InputAction.CallbackContext context)
    {
        isGrabbing = true;
       
    }

    public void Release(InputAction.CallbackContext context)
    {
        isGrabbing = false;
    }
}
