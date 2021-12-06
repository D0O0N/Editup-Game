using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterBehavior : MonoBehaviour
{

    private float movementSpeed = 15f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButton("Right"))
        {
            transform.position = transform.position + new Vector3(movementSpeed * Time.deltaTime,0, 0);
        }
        if (Input.GetButton("Left"))
        {
            transform.position = transform.position + new Vector3(-movementSpeed * Time.deltaTime, 0, 0);
        }
    }
}
