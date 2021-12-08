using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{

    AudioSource src;
    public AudioClip srcGood;
    public AudioClip srcBad;
    // Start is called before the first frame update
    void Start()
    {
        src = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponent<BallBehavior>().type == "P")
        {
            src.clip = srcBad;
            src.Play();
        }
        if (other.gameObject.GetComponent<BallBehavior>().type == "R")
        {
            src.clip = srcGood;
            src.Play();
        }
    }
}
