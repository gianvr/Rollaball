using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class OutOfLimits : MonoBehaviour
{
    void OnTriggerEnter(Collider collider)
    {
        PlayerController.count = -10;
        SceneManager.LoadScene("Scenes/Game Over");
    }
}
