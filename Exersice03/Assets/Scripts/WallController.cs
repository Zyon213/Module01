using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallController : MonoBehaviour
{
    [SerializeField] Material darkGreen;
    [SerializeField] Material darkRed;
    [SerializeField] string playerName;
 //   [SerializeField] GameObject wall;
    [SerializeField] GameObject bigWall;
    [SerializeField] float wallRaiseHeight = 5.0f;
    private float wallRaiseSpeed = 0.1f;
    private bool isRaise;
    
    // Start is called before the first frame update
    void Start()
    {
        this.GetComponent<MeshRenderer>().material = darkRed;

    }

    private void Update()
    {
        if (isRaise && bigWall.transform.position.y <= wallRaiseHeight)
        {
            bigWall.transform.position = new Vector3(bigWall.transform.position.x, bigWall.transform.position.y + wallRaiseSpeed, bigWall.transform.position.z);
            if (bigWall.transform.position.x >= wallRaiseHeight)
                bigWall.transform.position = new Vector3(bigWall.transform.position.x, wallRaiseHeight, bigWall.transform.position.z);

        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == playerName)
        {
       //     wall.GetComponent<Animator>().Play("WallRaise");
            this.GetComponent<MeshRenderer>().material = darkGreen;
            isRaise = true;
        }
    }
}
