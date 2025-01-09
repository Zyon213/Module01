using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveWall : MonoBehaviour
{
    [SerializeField] GameObject wall;
    private float wallUpHeight = 2.0f;
    private float wallUpSpeed = 0.01f;
    private float wallInitialPos;
    private bool isWallUp;

    private void Start()
    {
        wallInitialPos = wall.transform.position.y;
    }

    private void Update()
    {
        if (isWallUp)
            MoveWallUp();
    }

    private void MoveWallUp()
    {
        if (wall.transform.position.y <= wallInitialPos + wallUpHeight)
            wall.transform.position = new Vector3(wall.transform.position.x, wall.transform.position.y + wallUpSpeed, wall.transform.position.z);
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            isWallUp = true;
            Debug.Log("Move");
        }
    }
}
