using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangePathColor : MonoBehaviour
{
    [SerializeField] GameObject path;
    private MeshRenderer buttonMaterial;
    private Color buttonColor;
    private LayerMask layer;

    private void Start()
    {
        buttonMaterial = GetComponent<MeshRenderer>();
        buttonColor = buttonMaterial.material.color;
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player") && buttonColor == collision.gameObject.GetComponent<MeshRenderer>().material.color)
        {
            path.GetComponent<MeshRenderer>().material = buttonMaterial.material;
            path.gameObject.layer = collision.gameObject.layer;

        }
    }
}
