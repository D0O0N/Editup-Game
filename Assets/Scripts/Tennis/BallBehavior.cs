using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallBehavior : MonoBehaviour
{

    public string type = "";
    private Rigidbody body;
    private bool timeStart = false;
    private float timeLeft = 1f;
    // Start is called before the first frame update
    void Start()
    {
        body = this.GetComponent<Rigidbody>();
    }

    public void startTimer()
    {
        timeStart = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (timeStart)
        {
            timeLeft -= Time.deltaTime;
            if (timeLeft < 0)
            {
                body.velocity = transform.TransformDirection(Vector3.down * 3);
                timeStart = false;
            }
        }
    }
}
