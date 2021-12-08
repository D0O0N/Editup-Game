using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StarManager : MonoBehaviour
{
    public Sprite starBlue;
    public Sprite starYellow;
    public int comp;

    private int lvlComp = 0;

    public Image[] stars;
    // Start is called before the first frame update
    void Start()
    {
        lvlComp = PlayerPrefs.GetInt("LvlComp" + comp);
        ShowLvl();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void ShowLvl(){
        for (int i = 0; i < lvlComp; i++)
        {
            stars[i].sprite = starYellow;
        }        
    }
}
