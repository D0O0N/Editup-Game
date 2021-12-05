using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LifeBarBehavior : MonoBehaviour
{

    public float decreaseSpeed = 0.01f;
    private Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        float currentValue = animator.GetFloat("Status");
        animator.SetFloat("Status", currentValue - Time.deltaTime * decreaseSpeed);
    }
}
