using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    [SerializeField] float speedFactor;
    private string toUpTrigger = "ToUpTrigger";
    private string toDownTrigger = "ToDownTrigger";
    private string toLeftTrigger = "LeftTrigger";
    private string toRightTrigger = "RightTrigger";
    private string claire ="Claire";
    private string john = "John";
    private string thomas = "Thomas";
    private Rigidbody playerRb;
    public float horizontalInput;
    private float moveSpeed = 5.0f;
    private float jumpForce = 250.0f;
    private bool isOnGround = true;
    private Vector3 startPostion;
    private float gravityForce = 1.5f;
    private new CameraController camera;

    public Transform escalator;
    public bool isOnElevator = false;
    public bool isMoveToLeft = false;
    public bool isMoveToRight = false;
    public bool isAtExit = false;
    public bool isActive = false;
    public bool isDead = false;
    public bool toUp = false;
    public bool toDown = false;
    // Start is called before the first frame update
   
    void Start()
    {
        startPostion = this.transform.position;
        Physics.gravity *= gravityForce;
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
            this.transform.Translate(Vector3.right * Time.deltaTime * moveSpeed * speedFactor * horizontalInput);


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
        playerRb.AddForce(Vector3.up * jumpForce * speedFactor, ForceMode.Impulse);

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
            if (this.gameObject.name == claire)
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
            if (this.gameObject.name == john)
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
            if (this.gameObject.name == thomas)
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
