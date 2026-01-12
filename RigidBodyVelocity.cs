using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RigidBodyVelocity : MonoBehaviour
{
    private Rigidbody handtarget;
    // Start is called before the first frame update
    void Start()
    {
        handtarget = GetComponent<Rigidbody>();
        handtarget.maxAngularVelocity = 20f;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
