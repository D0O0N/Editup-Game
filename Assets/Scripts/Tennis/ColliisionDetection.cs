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
    public Animator client;
    public Animator character;
    public ParticleSystem particle;
    public ParticleSystem particle2;
    public Sprite SpriteAfter;
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
            if (currentValue > 0f){
                animator.SetFloat("Status", currentValue - MalusPointValue);
            }
            Rigidbody counter = other.attachedRigidbody;
            particle2.transform.position = counter.transform.position;
            particle2.Play();
            Destroy(other.gameObject);
            client.SetTrigger("Evil");
            character.SetTrigger("Sad");


        }
        if (other.gameObject.GetComponent<BallBehavior>().type == "R")
        {
            float currentValue = animator.GetFloat("Status");
            animator.SetFloat("Status", currentValue + BonusPointValue);
            Rigidbody counter = other.attachedRigidbody;
            counter.velocity = transform.TransformDirection(Vector3.down * -CounterSpeed);
            other.transform.GetChild(0).transform.GetComponent<SpriteRenderer>().sprite = SpriteAfter;
            other.transform.GetChild(0).transform.rotation = Quaternion.identity;

            particle.transform.position = counter.transform.position;
            particle.Play();
        }
        if (other.gameObject.name == "WhateverYouWant")
        {
           //Possibility of adding mor behaviors here
        }
    }
}
