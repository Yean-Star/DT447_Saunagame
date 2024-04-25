using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealingPad : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "Player")
        {
            Debug.Log("Player has enter the HealingPad");
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        
    }
}
