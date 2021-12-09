using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStart : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        // Retirer avant de build
        if (!PlayerPrefs.HasKey("LvlComp6")){
            LockAll();
        }
        
    }

    public void UnlockAll(){
        for (int i = 1; i < 7; i++)
        {
            PlayerPrefs.SetInt("LvlComp"+i, 3);
        }
    }

    public void LockAll(){
        for (int i = 1; i < 7; i++)
        {
            PlayerPrefs.SetInt("LvlComp"+i, 0);
        }
    }

    public void QuitGame(){
        Application.Quit();
    }
}
