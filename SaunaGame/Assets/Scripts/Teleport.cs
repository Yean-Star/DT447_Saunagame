using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleport : MonoBehaviour
{
    [SerializeField]
    private GameObject teleportSwap;
    [SerializeField]
    private GameObject player;


    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            player.transform.position = new Vector3(teleportSwap.transform.position.x,
                teleportSwap.transform.position.y + 1.0f, teleportSwap.transform.position.z);
        }
    }
}
