using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WarebunnySound : MonoBehaviour
{
    public AudioSource footsteps;
    public float sightRange;
    private bool playerInSightRange;
    public LayerMask whatIsPlayer;

    void Update()
    {
        playerInSightRange = Physics.CheckSphere(transform.position, sightRange, whatIsPlayer);
        
        if(playerInSightRange)
        {
            footsteps.Play();
        }
    }
}
