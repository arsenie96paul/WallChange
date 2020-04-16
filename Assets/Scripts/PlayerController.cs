using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    internal float moveSpeed = 0;

    [SerializeField]
    GameObject timerTxtParent;

    [SerializeField]
    ParticleSystem playerBurst;

    internal static bool left = false;
    internal static bool right = false;

    private bool startTimer = false;
    private float timer = 5;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        // Movement 
        transform.transform.Translate(Vector3.up * Time.deltaTime * moveSpeed);
        if (left && transform.position.x >= -1.5f)
        {
            transform.Translate(Vector3.left * Time.deltaTime * moveSpeed);
        }
        else if (right && transform.position.x <= 1.5f)
        {
            transform.Translate(Vector3.right * Time.deltaTime * moveSpeed);
        }

        // Timer 
        if (startTimer)
        {
            timer -= Time.deltaTime;
            timerTxtParent.transform.GetChild(0).gameObject.GetComponent<Text>().text = ((int)timer).ToString();
        }
        if ( timer <= 0 )
        {
            gameObject.GetComponent<MeshRenderer>().enabled = false;
            moveSpeed = 0;
            startTimer = false;
            playerBurst.Play();
            playerBurst = null;
            Invoke("ReturnToLobby", 2.5f);
        }

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            gameObject.GetComponent<MeshRenderer>().enabled = false;
            moveSpeed = 0;
            playerBurst.Play();
            playerBurst = null;
            Invoke("ReturnToLobby", 2.5f);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if ( other.gameObject.tag == "Wall")
        {
            startTimer = true;
            timer = 5f;
            timerTxtParent.SetActive(true);
        }
    }

    private void ReturnToLobby()
    {
        SceneManager.LoadScene(0);
    }
}
