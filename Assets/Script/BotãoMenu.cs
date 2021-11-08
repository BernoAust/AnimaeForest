using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BotãoMenu : MonoBehaviour
{
    
    public void BackToMenu()
    {
        GameObject.FindWithTag("GameManager").GetComponent<GameManager>().isPaused = false;
        Time.timeScale = 1f;
        SceneManager.LoadScene(0);
    }

}
