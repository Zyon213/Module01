using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedElevatorController : MonoBehaviour
{
    [SerializeField] string playerName;
    [SerializeField] GameObject wall;
    private bool isOnElavator = false;
    private PlayerController player;
    private float lowerBound;
    private float upperBound;
    private float elevatorSpeed = 0.02f;


    private void Start()
    {
        player = GameObject.Find(playerName).GetComponent<PlayerController>();
        lowerBound = transform.position.y;
        upperBound = wall.GetComponent<BoxCollider>().transform.position.y * 2.0f;
    }

    private void Update()
    {
        if (isOnElavator)
        {
            if (transform.position.y >= lowerBound && transform.position.y <= upperBound)
            {
                if (player.toUp)
                {
                    transform.position = new Vector3(transform.position.x, transform.position.y + elevatorSpeed, transform.position.z);
                }
                else if (player.toDown)
                {
                    transform.position = new Vector3(transform.position.x, transform.position.y - elevatorSpeed, transform.position.z);
                }

                if (transform.position.y <= lowerBound)
                    transform.position = new Vector3(transform.position.x, lowerBound, transform.position.z);
                if (transform.position.y >= upperBound)
                    transform.position = new Vector3(transform.position.x, upperBound, transform.position.z);
            }
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == playerName)
        {
            isOnElavator = true;
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.name == playerName)
            isOnElavator = false;
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
        {
            other.gameObject.transform.parent = null;
        }
    }

}
