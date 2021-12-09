using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManagerV2 : MonoBehaviour
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
        if (other.gameObject.GetComponent<BallBehaviorV2>().type == other.gameObject.GetComponent<BallBehaviorV2>().rep)
        {
            src.clip = srcGood;
            src.Play();
        } else {
            src.clip = srcBad;
            src.Play();
        }
    }
}
