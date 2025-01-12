using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionDetection : MonoBehaviour
{
    [SerializeField] GameObject exitSign;
    [SerializeField] string playerName;
    public bool isInside = false;

    private void Update()
    {
        if (isInside)
        {
            exitSign.gameObject.SetActive(true);
        }
        else
            exitSign.gameObject.SetActive(false);

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == playerName)
        {
            other.gameObject.GetComponent<PlayerController>().isAtExit = true;
            isInside = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.name == playerName)
        {
            other.gameObject.GetComponent<PlayerController>().isAtExit = false;
            isInside = false;
        }
    }
}
