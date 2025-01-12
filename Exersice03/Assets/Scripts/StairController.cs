using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StairController : MonoBehaviour
{
    [SerializeField] Material darkGreen;
    [SerializeField] Material darkRed;
    [SerializeField] string playerName;
    [SerializeField] GameObject stair;

    // Start is called before the first frame update
    void Start()
    {
        this.GetComponent<MeshRenderer>().material = darkRed;

    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == playerName)
        {
            this.GetComponent<MeshRenderer>().material = darkGreen;
            stair.GetComponent<Animator>().Play("FlipStair");
        }
    }
}
