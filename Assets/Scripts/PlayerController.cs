using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    public float speed = 0;
    public TextMeshProUGUI countText;
    public AudioSource pickUpAudioSource;
    public AudioSource dontPickUpAudioSource;


    private Rigidbody rb;
    public static int count;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        count = 0;

        SetCountText();
    }

    void SetCountText()
    {
        if(count < 0)
        {
            SceneManager.LoadScene("Scenes/Game Over");
        }else
        {
            countText.text =  "Pontos: " + count.ToString();
        }
        
    }

    void FixedUpdate()
    {
        MovePlayerRelativeToCamera();
    }

    // Source: https://www.youtube.com/watch?v=7kGCrq1cJew
    void MovePlayerRelativeToCamera()
    {
        float playerVerticalInput = Input.GetAxis("Vertical");
        float playerHorizontalInput = Input.GetAxis("Horizontal");

        Vector3 forward = Camera.main.transform.forward;
        Vector3 right = Camera.main.transform.right;
        forward.y = 0;
        right.y = 0;
        forward = forward.normalized;
        right = right.normalized;

        Vector3 forwardRelativeVerticalInput = playerVerticalInput * forward;
        Vector3 rightRelativeHorizontalInput = playerHorizontalInput * right;

        Vector3 cameraRelativeMovement = forwardRelativeVerticalInput + rightRelativeHorizontalInput;
        rb.AddForce(cameraRelativeMovement * speed);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("PickUp"))
        {
            other.gameObject.SetActive(false);
            count++;
            pickUpAudioSource.Play();
            SetCountText();

        }
        else if(other.gameObject.CompareTag("DontPickUp"))
        {
            other.gameObject.SetActive(false);
            if (count< 5)
            {
                count--;
            }
            else if (count < 10)
            {
                count -= 2;
            }else
            {
                count /= 2;
            }
            if (count >= 0)
            {
                dontPickUpAudioSource.Play();
            }
            SetCountText();
        }
    }
}
