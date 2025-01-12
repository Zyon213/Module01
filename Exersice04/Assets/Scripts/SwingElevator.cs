using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwingElevator : MonoBehaviour
{
    [SerializeField] GameObject leftPoint;
    [SerializeField] GameObject rightPoint;
    [SerializeField] string playerName;
    private DetectPlayer player;
    private float elevatorSpeed = 0.025f;
    private bool isOnElevator = false;


    private void Start()
    {
        player = GameObject.Find(playerName).GetComponent<DetectPlayer>();
    }
    private void Update()
    {
        if (isOnElevator)
        {
            if (player.moveToLeft)
                this.transform.position = new Vector3(this.transform.position.x - elevatorSpeed, this.transform.position.y , this.transform.position.z);
            else if (player.movetToRight)
                this.transform.position = new Vector3(this.transform.position.x + elevatorSpeed , this.transform.position.y, this.transform.position.z);
            if (this.transform.position.x < leftPoint.transform.position.x)
                this.transform.position = new Vector3(leftPoint.transform.position.x, this.transform.position.y, this.transform.position.z);
            else if (this.transform.position.x > rightPoint.transform.position.x)
                this.transform.position = new Vector3(rightPoint.transform.position.x, this.transform.position.y, this.transform.position.z);
        }

    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == playerName)
        {
            isOnElevator = true;
            other.gameObject.transform.parent = this.transform;
        }
    }


    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.name == playerName)
        {
            isOnElevator = false;
            other.gameObject.transform.parent = null;
        }
    }
}
