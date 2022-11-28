using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FinishLine : MonoBehaviour
{

    [SerializeField] float loadDelay = 1f;
    [SerializeField] ParticleSystem finishEffect;


    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            GetComponent<AudioSource>().Play();
            Invoke("ReloadedScene", 1);
            finishEffect.Play();
        }
    }



    void ReloadedScene()
    {
        SceneManager.LoadScene(0);
    }
}
