using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameplayEventsHandeler : MonoBehaviour
{
    public static Action GameOver;

    public static Action GameStarted;

    private void OnEnable()
    {
        GameOver += GameRestart;
    }

    private void OnDisable()
    {
        GameOver -= GameRestart;
    }

    private void GameRestart() 
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space)) 
        {
            GameStarted?.Invoke();
        }
    }
}
