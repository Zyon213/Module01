using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlueWallRaise : MonoBehaviour
{
    private Animator anim;
    private string playerName = "Claire";

    private void Start()
    {
        anim = GetComponent<Animator>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == playerName)
        {
            anim.Play("WallRaise");
        }
    }
}
