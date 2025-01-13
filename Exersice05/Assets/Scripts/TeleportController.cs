using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleportController : MonoBehaviour
{
    [SerializeField] string playerName;
    [SerializeField] Transform teleportOut;
    private bool isTeleport;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == playerName)
        {
            other.gameObject.transform.position = teleportOut.transform.position;
        }
    }
}
