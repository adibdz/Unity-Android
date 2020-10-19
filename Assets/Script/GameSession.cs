using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameSession : MonoBehaviour
{

    [SerializeField] int playerLives = 3;

    private void Awake()
    {
        int numberGameSession = FindObjectsOfType<GameSession>().Length;
        if(numberGameSession > 1)
        {
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }
    }



    public void ProcessPlayerDeath()
    {
        if(playerLives > 1)
        {
            TakeNewLife();
        }
        else
        {
            ResetGameSession();
        }
    }

    private void TakeNewLife()
    {
        playerLives--;
        var currenSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currenSceneIndex);
    }

    private void ResetGameSession()
    {
        SceneManager.LoadScene(0);
        Destroy(gameObject);
    }
}
