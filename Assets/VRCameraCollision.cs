using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VRCameraCollision : MonoBehaviour
{
    public Transform player; // Przypisz SteamVR Player

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Wall")) // Nadaj œcianom tag "Wall"
        {
            Vector3 pushBack = (player.position - other.ClosestPoint(player.position)).normalized * 10f;
            player.position += pushBack;
        }
    }
}
