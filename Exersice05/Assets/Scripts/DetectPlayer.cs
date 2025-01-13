using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectPlayer : MonoBehaviour
{
    [SerializeField] string leftPos;
    [SerializeField] string rightPos;
    public bool moveToLeft = false;
    public bool movetToRight = false;


    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.name == leftPos)
        {
            moveToLeft = false;
            movetToRight = true;
        }

        else if (other.gameObject.name == rightPos)
        {
            movetToRight = false;
            moveToLeft = true;
        }
    }



}
