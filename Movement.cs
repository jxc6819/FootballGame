using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.InputSystem;




public class Movement : MonoBehaviour
{
    [SerializeField] private InputActionReference LeftjumpActionReference;
    [SerializeField] private InputActionReference RightjumpActionReference;

    public GameObject RightHand;
    public GameObject LeftHand;
    public Rigidbody Body;
    public GameObject bodyPos;
    public bool isSprinting;
    public bool isJumping;
    public float jumpForce = 20f;
    public bool isGrounded => Physics.Raycast(new Vector2(transform.position.x, transform.position.y + 2.0f), Vector3.down, 2.0f);
    public UnityEngine.XR.Interaction.Toolkit.ActionBasedContinuousMoveProvider speed;


    // Start is called before the first frame upd

    private void Start()
    {
     //   LeftjumpActionReference.action.performed += OnJump;
        RightjumpActionReference.action.performed += OnJump;

        

       

        
    }
    private void Update()
    {
        
        StartCoroutine("CheckRunning");
        StartCoroutine("JumpDistance");
        //StartCoroutine("JumpBooll");

    }
    public IEnumerator CheckRunning()
    {
        speed = GetComponent<UnityEngine.XR.Interaction.Toolkit.ActionBasedContinuousMoveProvider>();

        
        Vector3 LstartVector = bodyPos.transform.position - LeftHand.transform.position;
        Vector3 RstartVector = bodyPos.transform.position - RightHand.transform.position;
        float LYstartPos = bodyPos.transform.position.y - LeftHand.transform.position.y;
        float RYstartPos = bodyPos.transform.position.y - RightHand.transform.position.y;
        yield return new WaitForSeconds(0.3f);
        Vector3 RfinalVector = bodyPos.transform.position - RightHand.transform.position;
        Vector3 LfinalVector = bodyPos.transform.position - LeftHand.transform.position;
        float LYfinalPos = bodyPos.transform.position.y - LeftHand.transform.position.y;
        float RYfinalPos = bodyPos.transform.position.y - RightHand.transform.position.y;
        float RstartPos = Math.Abs(RstartVector.x);
        float RfinalPos = Math.Abs(RfinalVector.x);
        float LstartPos = Math.Abs(LstartVector.x);
        float LfinalPos = Math.Abs(LfinalVector.x);
        float RZstartPos = Math.Abs( RstartVector.z);
        float RZfinalPos = Math.Abs( RfinalVector.z);
        float LZstartPos = Math.Abs(LstartVector.z);
        float LZfinalPos = Math.Abs(LfinalVector.z);


        if ((RstartPos - RfinalPos >= 0.15 || LstartPos - LfinalPos >= 0.15) || (RfinalPos - RstartPos >= 0.15 || LfinalPos - LstartPos >= 0.15) || (LYstartPos - LYfinalPos >= 0.15 || RYstartPos - RYfinalPos >= 0.15))
        {
            speed.moveSpeed = 6;
            isSprinting = true;
        }


        if ((RstartPos - RfinalPos <= 0.15 && LstartPos - LfinalPos <= 0.15) && (RZstartPos - RZfinalPos <= 0.15 && LZstartPos - LZfinalPos <= 0.15) && (LYstartPos - LYfinalPos <= 0.15 && RYstartPos - RYfinalPos <= 0.15))
        {
            yield return new WaitForSeconds(0.5f);

            if ((RstartPos - RfinalPos <= 0.15 && LstartPos - LfinalPos <= 0.15) && (RZstartPos - RZfinalPos <= 0.15 && LZstartPos - LZfinalPos <= 0.15) && (LYstartPos - LYfinalPos <= 0.15 && RYstartPos - RYfinalPos <= 0.15))
            {
                speed.moveSpeed = 2.5f;
                isSprinting = false;
            }

        }
        if ((RZstartPos - RZfinalPos >= 0.15 || LZstartPos - LZfinalPos >= 0.15) || (RZfinalPos - RZstartPos >= 0.15 || LZfinalPos - LZstartPos >= 0.15))
        {
            speed.moveSpeed = 6;
            isSprinting = true;
        }


       


    }

    public IEnumerator JumpDistance()
    {
        float RJstartPos = RightHand.transform.position.y;
        float LJstartPos = LeftHand.transform.position.y;
        yield return new WaitForSeconds(0.5f);
        float RJfinalPos = RightHand.transform.position.y;
        float LJfinalPos = LeftHand.transform.position.y;

        if (RJstartPos - RJfinalPos >= 0.15 || LJstartPos - LJfinalPos >= 0.15)
        {
            isJumping = true;
            
        }
        if (RJstartPos - RJfinalPos <= 0.15 || LJstartPos - LJfinalPos <= 0.15)
        {
            yield return new WaitForSeconds(0.01f);
            if (RJstartPos - RJfinalPos <= 0.15 || LJstartPos - LJfinalPos <= 0.15)
            {
                isJumping = false;
            }
        }


        if(JumpCoolDown == false)
        {
            yield return new WaitForSeconds(3);
            JumpCoolDown = true;
        }
    }
    public bool JumpCoolDown;
    public bool JumpButton;
    //public void JumpBool(InputAction.CallbackContext obj)
    //{
    //    JumpButton = true;
       
    //}

    //public IEnumerator JumpBooll()
    //{
    //    if(JumpButton == true)
    //    {
    //        yield return new WaitForSeconds(1);
    //        JumpButton = false;
            

    //    }
    //}

   
    public void OnJump(InputAction.CallbackContext obj)
    {
        

        if (isJumping == true && JumpCoolDown == true )
        {
         
            Body.AddForce(Vector3.up * jumpForce);
            JumpCoolDown = false;
        }
         

    }
   
    
}
