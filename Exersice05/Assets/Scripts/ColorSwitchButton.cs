using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorSwitchButton : MonoBehaviour
{
    [SerializeField] GameObject[] doors;
    private Color buttonColor;
    private GameObject matchColorDoor;
    private bool isButtonPressed;
    private float doorOpenHeight = 7.0f;
    private float doorOpenSpeed = 0.1f;

    private void Start()
    {
        buttonColor = GetComponent<MeshRenderer>().material.color;
    }

    private void Update()
    {
        matchColorDoor = ColorDoor();
        if (isButtonPressed && matchColorDoor.transform.position.y <= doorOpenHeight)
        {
            matchColorDoor.transform.position = new Vector3(matchColorDoor.transform.position.x, 
                matchColorDoor.transform.position.y + doorOpenSpeed, matchColorDoor.transform.position.z);
        }
    }

    private GameObject ColorDoor()
    {
        foreach (GameObject door in doors)
        {
            if (door.GetComponent<MeshRenderer>().material.color == buttonColor)
            {
                return door;
            }
        }
        return null;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            isButtonPressed = true;
        }
    }
}
