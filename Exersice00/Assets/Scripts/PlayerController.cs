using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    [SerializeField] float moveSpeed = 5.0f;
    [SerializeField] float jumpForce = 250.0f;
    private Rigidbody playerRb;
    private float horizontalInput;
    private bool isOnGround = true;
    private Vector3 startPostion;
    private float gravityForce = 1.5f;

    private new CameraController camera;


    public bool isActive = false;
    // Start is called before the first frame update
    void Start()
    {
        startPostion = this.transform.position;
        camera = GameObject.Find("Main Camera").GetComponent<CameraController>();
        playerRb = this.gameObject.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        SwitchPlayer();
        if (this.isActive)
        {
            // player moves
            horizontalInput = Input.GetAxis("Horizontal");
            this.transform.Translate(Vector3.right * Time.deltaTime * moveSpeed * horizontalInput);


            // player jump
            if (Input.GetKeyDown(KeyCode.Space) && this.isOnGround)
            {
                Jump();
                this.isOnGround = false;
            }
        }
        if (Input.GetKeyDown(KeyCode.R))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }

    }
    private void Jump()
    {
        playerRb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);

    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground") || collision.gameObject.CompareTag("Player"))
        {
            this.isOnGround = true;
        }
    }

    public void SwitchPlayer()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            if (this.gameObject.name == "Claire")
            {
                this.isActive = true;
            }
            else
            {
                this.isActive = false;
            }

        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            if (this.gameObject.name == "John")
            {
                this.isActive = true;
            }
            else
            {
                this.isActive = false;
            }
        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            if (this.gameObject.name == "Thomas")
            {
                this.isActive = true;
            }
            else
            {
                this.isActive = false;
            }
        }
    }
}
