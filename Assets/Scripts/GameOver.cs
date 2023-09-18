using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameOver : MonoBehaviour
{
    public TextMeshProUGUI feedback;
    public AudioSource winAudio;
    public AudioSource loseAudio;
    public AudioSource musicAudio;
    // Start is called before the first frame update
    void Start()
    {   
        if(PlayerController.count == -20)
        {
            feedback.text = "Timed Out";
            loseAudio.Play();
        }
        else if(PlayerController.count == -10)
        {
            feedback.text = "Out of Limits";
            loseAudio.Play();
        }
        else if(PlayerController.count < 0)
        {
            feedback.text = "You Lose!";
            loseAudio.Play();
        }else
        {
            feedback.text = "Score: " + PlayerController.count.ToString();
            winAudio.Play();
        }
        Invoke("PlayMusic", 3f);
    }

    void PlayMusic(){
        musicAudio.Play();
    }
}
