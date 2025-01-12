using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MatchColorButton : MonoBehaviour
{
    [SerializeField] GameObject[] doors;
    [SerializeField] GameObject[] buttons;
    private GameObject matchDoorColor;
    private Color buttonColor;
    private Color initialColor;
    private MeshRenderer buttonMaterial;
    private bool isWhiteColor = true;
    private float doorOpenHeight = 7.0f;
    private float doorOpenSpeed = 0.1f;

    private void Start()
    {
        buttonMaterial = GetComponent<MeshRenderer>();
        initialColor = buttonMaterial.material.color;
    }

    private void Update()
    {
        if (!isWhiteColor)
        {
            matchDoorColor = MatchDoor(buttonColor);
            if (matchDoorColor.transform.position.y <= doorOpenHeight)
            {
                matchDoorColor.transform.position = new Vector3(matchDoorColor.transform.position.x,
                    matchDoorColor.transform.position.y + doorOpenSpeed, matchDoorColor.transform.position.z);
            }

        }
    }

    private GameObject MatchDoor(Color btnColor)
    {
        foreach (GameObject door in doors)
        {
            if (btnColor == door.GetComponent<MeshRenderer>().material.color)
            {
                return door;
            }
        }
        return null;
    }


    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player") && isWhiteColor)
         {
            foreach (GameObject button in buttons)
            {
                if (button.GetComponent<MeshRenderer>().material.color == collision.gameObject.GetComponent<MeshRenderer>().material.color)
                    return;
            }
            buttonMaterial.material = collision.gameObject.GetComponent<MeshRenderer>().material;
            buttonColor = buttonMaterial.material.color;
            isWhiteColor = false;
        }
    }
}
