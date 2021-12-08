using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterBehavior : MonoBehaviour
{

    private bool gameStop = false;

    public void stoop()
    {
        gameStop = true;
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!gameStop)
        {
            Vector2 screenPosition = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
            Vector2 worldPosition = Camera.main.ScreenToWorldPoint(screenPosition);
            if (worldPosition.x > -4 && worldPosition.x < 4)
            {
                transform.position = new Vector3(worldPosition.x, -2.18f, 0);
            }
        }
    }
}
