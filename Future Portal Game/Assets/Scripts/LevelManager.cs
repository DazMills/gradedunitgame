using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; 

public class LevelManager : MonoBehaviour
{
    public string TargetScene;

    public void StartGame()
    {
        SceneManager.LoadScene("Level One");
    }

    public void StartScreen()
    {
        
    SceneManager.LoadScene("Start Screen");
        }
    public void GameOver()
    {
        SceneManager.LoadScene("GameOver");
    }

    public void WinScreen()
    {
        SceneManager.LoadScene("WinScreen");
    }

    public void LevelTwo()
    {
        SceneManager.LoadScene("Level Two");
    }


    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            SceneManager.LoadScene(TargetScene);
        }
    }
   
        
    

} 

