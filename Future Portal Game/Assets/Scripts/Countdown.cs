using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Threading;
using UnityEngine.SceneManagement;

public class Countdown : MonoBehaviour
{
    //what the time begins on
    public int timeLeft = 40;
    public Text countdown;


    void Start()
    {
        StartCoroutine("LoseTime");
        Time.timeScale = 1;
    }

    // 
    void Update()
    {
        countdown.text = ("Time:" + timeLeft);

        if (timeLeft <= 0)
            GameOver();
    }


    //trigger game over after timer reaches 0
    private void GameOver()
    {
        SceneManager.LoadScene("GameOver");

    }

    IEnumerator LoseTime()
    {
        while (true)
        {
            yield return new WaitForSeconds(1);
            timeLeft--;
        }
    }
}