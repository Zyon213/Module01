using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorButton : MonoBehaviour
{
    [SerializeField] GameObject door;
    private float openHeight = 7.0f;
    private MeshRenderer buttonColor;
    private float doorOpenSpeed = 0.1f;
    private bool isDoorOpen;

    private void Start()
    {
        buttonColor = GetComponent<MeshRenderer>();
    }

    private void Update()
    {
        if (isDoorOpen && door.transform.position.y <= openHeight)
        {
            door.transform.position = new Vector3(door.transform.position.x, door.transform.position.y + doorOpenSpeed, door.transform.position.z);
        }
    }
 
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.GetComponent<MeshRenderer>().material.color == buttonColor.material.color)
        {
            isDoorOpen = true;
            Debug.Log("matched");
            
        }
    }
    
}
