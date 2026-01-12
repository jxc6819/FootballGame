using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PlayerFollow : MonoBehaviour
{
    public NavMeshAgent defender;
    public Transform StreakPlayer;
    
  
    void Update()
    {
        defender.SetDestination(StreakPlayer.position);
        
    }
}
