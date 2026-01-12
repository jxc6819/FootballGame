using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.XR.Interaction.Toolkit;
public class TargetGrip : MonoBehaviour
{
    [SerializeField] private ActionBasedController controller;
    private bool isGrabbing;
    public GameObject Football;
    public GameObject Hand;

    // Start is called before the first frame update
    void Start()
    {
        controller.selectAction.action.started += Grab;
        controller.selectAction.action.canceled += Release;

    }

    // Update is called once per frame
    void Update()
    {
        if (isGrabbing == true)
            {
            GameObject FootballClone = Instantiate(Football);
            FootballClone.transform.position = Hand.transform.position;
            }
       
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