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

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "BadSentence(Clone)")
        {
            src.clip = srcBad;
            src.Play();
        }
        if (other.gameObject.name == "GoodSentence(Clone)")
        {
            src.clip = srcGood;
            src.Play();
        }
    }
}
