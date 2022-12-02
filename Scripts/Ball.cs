using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Ball : MonoBehaviour
{
    public Animator BallAnim;
    public Rigidbody BallRB;
    public CameraFollow Camera;
    public GameObject SplashFX;
    public GameObject GameOverPanel;
    public AudioSource Audio;
    public AudioClip BoltAudio;
    public AudioClip CoinAudio;

    public float ForceValue;

    [HideInInspector]
    public bool IsFly;
    public static bool IsGameOver;

    private bool _setUpvelocity;

    private void Start()
    {
        IsFly = false;
        IsGameOver = false;
        Physics.gravity = new Vector3(0, -20f, 0);
    }

    private void LateUpdate()
    {
        if (_setUpvelocity)
        {
            Audio.PlayOneShot(BoltAudio);
            BallAnim.SetTrigger("Jump");
            BallRB.velocity = new Vector3(0f, 8f, 0f);
            _setUpvelocity = false;
            IsFly = false;
        }
    }
    private void OnCollisionEnter(Collision other)
    {
        if (other.collider.tag == "Fail")
        {
            Fail();   
        }
        else
        {
            _setUpvelocity = true;
            GameObject particle = Instantiate(SplashFX, other.transform, false);
            particle.transform.position = new Vector3(other.transform.position.x, other.transform.position.y + 0.01f, other.transform.position.z - 1.5f);
            particle.transform.rotation = Quaternion.Euler(90f, 0, Random.Range(0, 360f));
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "HelixPlatform")
        {
            ScoreManager.Instance.AddScore();
            Audio.PlayOneShot(CoinAudio);
            IsFly = true;
        }
    }

    private void Fail()
    {
        IsGameOver = true;
        ScoreManager.Instance.SetBestScore();
        GameOverPanel.SetActive(true);
        Time.timeScale = 0;
    }

    public void Restert()
    {
        SceneManager.LoadScene("Main");
    }
}
