using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CrashDetector : MonoBehaviour
{

    [SerializeField] float loadDelay = 1f;
    [SerializeField] ParticleSystem crashEffect;
    [SerializeField] AudioClip crashSFX;

    bool hasCrashed = false;

    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Ground" && hasCrashed==false)
        {
            hasCrashed = true;
            GetComponent<AudioSource>().PlayOneShot(crashSFX);
            Invoke("ReloadedScene", loadDelay);
            crashEffect.Play();
            GetComponent<PlayerController>().disableControl();
        }

    }

    void ReloadedScene()
    {
        SceneManager.LoadScene(0);
    }
}
