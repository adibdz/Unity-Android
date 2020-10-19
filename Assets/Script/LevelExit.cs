using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelExit : MonoBehaviour
{
    

    
    public void PlayerTouchLevelExit()
    {
        
        StartCoroutine(whenPlayerTouchExit());
    }

    IEnumerator whenPlayerTouchExit()
    {
        yield return new WaitForSeconds(2f);
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex + 1);
    }
}
