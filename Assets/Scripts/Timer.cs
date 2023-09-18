using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

//Source: https://www.youtube.com/watch?v=hxpUk0qiRGs
public class Timer : MonoBehaviour
{   
    public TextMeshProUGUI TimerText;
    public float TimeLeft;
    public bool TimerOn = false;
    // Start is called before the first frame update
    void Start()
    {
        TimerOn = true;
    }

    // Update is called once per frame
    void Update()
    {
        if(TimerOn)
        {
            if(TimeLeft>0)
            {
                TimeLeft -= Time.deltaTime;
                updateTimer(TimeLeft);
            }
            else
            {
                TimeLeft = 0;
                TimerOn = false;
                PlayerController.count = -20;
                SceneManager.LoadScene("Scenes/Game Over");
            }
            
        }
    } 

    void updateTimer(float currentTime)
    {
        currentTime+=1;

        float minutes = Mathf.FloorToInt(currentTime / 60);
        float seconds = Mathf.FloorToInt(currentTime % 60);

        TimerText.text = string.Format("Timer: {0:00}:{1:00}", minutes, seconds);
    }
}
