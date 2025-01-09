using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenWall : MonoBehaviour
{
    [SerializeField] GameObject leftWall;
    [SerializeField] GameObject rightWall;
    private float leftWallInitialPos;
    private float rightWallInitialPos;
    private float wallOpenSpeed = 0.01f;
    private float openDistance = 1.0f;
    private bool isDoorOpen;

    private void Start()
    {
        leftWallInitialPos = leftWall.transform.position.z;
        rightWallInitialPos = rightWall.transform.position.z;
    }

    private void Update()
    {
        if (isDoorOpen)
            OpenDoor();
    }
    private void OpenDoor()
    {
        if (leftWall.transform.position.z > leftWallInitialPos - openDistance)
            leftWall.transform.position = new Vector3(leftWall.transform.position.x, leftWall.transform.position.y, leftWall.transform.position.z - wallOpenSpeed);
        if (rightWall.transform.position.z < rightWallInitialPos + openDistance)
            rightWall.transform.position = new Vector3(rightWall.transform.position.x, rightWall.transform.position.y, rightWall.transform.position.z + wallOpenSpeed);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            isDoorOpen = true;
        }
    }
}
