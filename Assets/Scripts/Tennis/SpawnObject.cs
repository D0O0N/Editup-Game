using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnObject : MonoBehaviour
{

    public float Speed = 5f;
    public float maxTime = 3f;
    public float minTime = 0f;
    public Rigidbody badSentence;
    public Rigidbody goodSentence;
    float timeLeft = 1f;
    private int random;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timeLeft -= Time.deltaTime;
        if (timeLeft < 0)
        {

            Rigidbody clone;
            random = Random.Range(0, 2);
            if(random == 0){
                clone = Instantiate(badSentence, transform.position + new Vector3(Random.Range(-5f, 5f), 0, 0), transform.rotation);
                clone.velocity = transform.TransformDirection(Vector3.down * Speed);
            }
            if(random == 1){
                clone = Instantiate(goodSentence, transform.position + new Vector3(Random.Range(-5f, 5f), 0, 0), transform.rotation);
                clone.velocity = transform.TransformDirection(Vector3.down * Speed);
            }
            timeLeft = Random.Range(minTime, maxTime);
        }
    }
}
