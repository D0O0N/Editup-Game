using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColliisionDetection : MonoBehaviour
{

    public float CounterSpeed = 10f;
    public float BonusPointValue = 0.1f;
    public float MalusPointValue = 0.1f;
    public GameObject lifeBar;
    private Animator animator;
    public ParticleSystem particle;
    // Start is called before the first frame update
    void Start()
    {
        animator = lifeBar.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponent<BallBehavior>().type == "P")
        {
            float currentValue = animator.GetFloat("Status");
            animator.SetFloat("Status", currentValue - MalusPointValue);
            Destroy(other.gameObject);

        }
        if (other.gameObject.GetComponent<BallBehavior>().type == "R")
        {
            float currentValue = animator.GetFloat("Status");
            animator.SetFloat("Status", currentValue + BonusPointValue);
            Rigidbody counter = other.attachedRigidbody;
            counter.velocity = transform.TransformDirection(Vector3.down * -CounterSpeed);

            particle.transform.position = counter.transform.position;
            particle.Play();
        }
        if (other.gameObject.name == "WhateverYouWant")
        {
           //Possibility of adding mor behaviors here
        }
    }
}
