using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BridgeController : MonoBehaviour
{
    [SerializeField] GameObject bridge;
    [SerializeField] GameObject blueEscalator;
    [SerializeField] Material darkGreen;
    [SerializeField] Material darkRed;
    [SerializeField] string playerName;
    void Start()
    {
        this.GetComponent<MeshRenderer>().material = darkRed;
        bridge.gameObject.SetActive(false);
        blueEscalator.gameObject.SetActive(true);
    }


    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == playerName)
        {

            bridge.gameObject.SetActive(true);
            blueEscalator.gameObject.SetActive(false);
            this.GetComponent<MeshRenderer>().material = darkGreen;
        }
    }
}
