using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] GameObject[] players;
    private GameObject activePlayer = null;
    private GameObject player;
    public Vector3 offset;
    private float followHeight = 0.5f;

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


    private GameObject ActivePlayer()
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

}
