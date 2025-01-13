using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CameraController : MonoBehaviour
{
    [SerializeField] GameObject[] players;
    private GameObject activePlayer = null;
    private GameObject player;
    public Vector3 offset;
    private float followHeight = 0.5f;
    private const string scene01 = "Stage1";
    private const string scene02 = "Stage2";
    private const string scene03 = "Stage3";
    private const string scene04 = "Stage4";
    private const string scene05 = "Stage5";
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
            if (currentScene.Equals(scene01))
                SceneManager.LoadScene(scene02, LoadSceneMode.Single);
            else if (currentScene == scene02)
                SceneManager.LoadScene(scene03, LoadSceneMode.Single);
            else if (currentScene == scene03)
                SceneManager.LoadScene(scene04, LoadSceneMode.Single);
            else if (currentScene == scene04)
                SceneManager.LoadScene(scene05, LoadSceneMode.Single);
            else if (currentScene == scene05)
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
