using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RotatingBlade : MonoBehaviour
{
    private float rotateAngle = 90.0f;
    private float bladeUpHeight = 2.0f;
    private float bladeInitialPos;
    private float bladeSpeed = 0.005f;
    private int sign = 1;
    // Start is called before the first frame update
    void Start()
    {
        bladeInitialPos = transform.position.y;
    }

    // Update is called once per frame
    void Update()
    {
        RotateBlade();
        BladeMove();
    }

    private void RotateBlade()
    {
        transform.Rotate(Vector3.up * rotateAngle * Time.deltaTime);
    }

    private void BladeMove()
    {
        transform.position = new Vector3(transform.position.x, transform.position.y + (bladeSpeed * sign) , transform.position.z);
        if (transform.position.y <= bladeInitialPos)
        {
            sign = -sign;
         //   transform.position = new Vector3(transform.position.x, bladeInitialPos, transform.position.z);
        }
        if (transform.position.y >= bladeInitialPos + bladeUpHeight)
        {
            sign = -sign;
         //   transform.position = new Vector3(transform.position.x, bladeUpHeight, transform.position.z);
        }       
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Debug.Log("Game Over");
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        //    QuitGame();
        }
    }

    private void QuitGame()
    {
    #if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
    #else
    Application.Quit();
    #endif
    }

}
