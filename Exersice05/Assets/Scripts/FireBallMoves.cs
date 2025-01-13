using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FireBallMoves : MonoBehaviour
{
    [SerializeField] float ballSpeed;
    private float ballDistance = 5.0f;
    private float initialPoint;

    private void Start()
    {
        initialPoint = transform.position.x;
    }

    private void Update()
    {
        transform.transform.Translate(Vector3.up * ballSpeed * Time.deltaTime);

        if (Mathf.Abs(initialPoint - transform.position.x) >= ballDistance)
        {
            Destroy(gameObject);
        }  
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Debug.Log("Game Over");
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);

            //  QuitGame();

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
