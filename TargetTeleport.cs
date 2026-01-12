using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetTeleport : MonoBehaviour
{
    public GameObject tpPoint;
    public void OnCollisionEnter(Collision collision)
    {
        gameObject.transform.position = tpPoint.transform.position;
    }
}
