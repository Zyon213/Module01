using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CameraController : MonoBehaviour
{
    [SerializeField] GameObject[] players;
    private string scene01 = "Stage1";
    private string scene02 = "Stage2";
    private GameObject activePlayer = null;
    private GameObject player;
    public Vector3 offset;
    private float followHeight = 0.5f;
    private string currentScene;

    // Start is called before the first frame update
    void Start()
    {
        offset = this.transform.position;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        this.player = ActivePlayer();
        if (player != null)
        {
            if (player.transform.position.y >= followHeight)
            {
                transform.position = new Vector3(player.transform.position.x, transform.position.y, player.transform.position.z + offset.z);

            }
        }
    }

    private void Update()
    {
        currentScene = SceneManager.GetActiveScene().name;
        if (CheckExit())
        {
            if (currentScene == scene01)
                SceneManager.LoadScene(scene02, LoadSceneMode.Single);
            else if (currentScene == scene02)
                SceneManager.LoadScene(scene01, LoadSceneMode.Single);

            Debug.Log("Game Over");
        }
    }

    public GameObject ActivePlayer()
    {
        foreach(GameObject currentPlayer in players)
        {
            if (currentPlayer.gameObject.GetComponent<PlayerController>().isActive)
            {
                activePlayer = currentPlayer;
                return activePlayer;
            }
        }
        return null;
    }


    private bool CheckExit()
    {
        foreach (GameObject player in players)
        {
            if (!player.GetComponent<PlayerController>().isAtExit)
            {
                return false;
            }
        }
        return true;
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}
