using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallSpawner : MonoBehaviour
{
    [SerializeField] GameObject ball;
    [SerializeField] GameObject ballFirePoint;
    [SerializeField] float shootGap;
    private float shootStart = 0.0f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        shootStart += Time.deltaTime;
        if (shootStart >= shootGap)
        {
            RandomBallGenerator();
            shootStart = 0;
        }
    }

    private GameObject RandomBallGenerator()
    {
        return Instantiate(ball, ballFirePoint.transform.position, ball.transform.rotation);
    }



}
