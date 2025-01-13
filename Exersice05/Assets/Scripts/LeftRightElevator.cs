using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeftRightElevator : MonoBehaviour
{
    [SerializeField] Transform left;
    [SerializeField] Transform right;
    private float elevatorSpeed = 0.015f;
    private int sign = 1;

    private void Update()
    {
        LeftRight();
    }
    private void LeftRight()
    {
        transform.position = new Vector3(transform.position.x + (sign * elevatorSpeed), transform.position.y, transform.position.z);
        if (transform.position.x < left.transform.position.x)
            sign = -sign;
        if (transform.position.x > right.transform.position.x)
            sign = -sign;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.gameObject.transform.parent = this.transform;
        }
    }
    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.gameObject.transform.parent = null;
        }
    }


}
