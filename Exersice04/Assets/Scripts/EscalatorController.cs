using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EscalatorController : MonoBehaviour
{
    [SerializeField] string playerName;
    private float speed = 10.0f;
    private PlayerController player;

    private float rightBound = 12.5f;
    private float leftBound = 9.2f;
    private float escalatorSpeed = 0.02f;
    public Vector3 startPos;
    private 

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find(playerName).GetComponent<PlayerController>();
        startPos = transform.position;
    }


    private void Update()
    {
        if (player.isDead)
        {
            transform.position = startPos;
            player.isDead = false;
        }
        if (player.isOnElevator)
        {
            if (transform.position.x >= leftBound && transform.position.x <= rightBound)
            {
                if (player.isMoveToRight)
                {
                    transform.position = new Vector3(transform.position.x + escalatorSpeed, transform.position.y, transform.position.z);
                }
                else if (player.isMoveToLeft)
                {
                    transform.position = new Vector3(transform.position.x - escalatorSpeed, transform.position.y, transform.position.z);
                }
            }

            if (transform.position.x < leftBound)
            {
                transform.position = new Vector3(leftBound, transform.position.y, transform.position.z);
            }
            if (transform.position.x > rightBound)
            {
                transform.position = new Vector3(rightBound, transform.position.y, transform.position.z);
            }

        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == playerName)
        {
            Debug.Log("on elevator");
            player.isOnElevator = true;
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.name == playerName)
        {
            player.isOnElevator = false;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == playerName)
        {
            other.gameObject.transform.parent = this.transform;
        }
    }


    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.name == playerName)
            other.gameObject.transform.parent = null;

    }


}

