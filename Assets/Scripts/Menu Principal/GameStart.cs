using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStart : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        for (int i = 1; i < 7; i++)
        {
            PlayerPrefs.SetInt("LvlComp"+i, 1);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
