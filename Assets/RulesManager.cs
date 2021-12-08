using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RulesManager : MonoBehaviour
{
    public Sprite[] rules;
    int actualComp;
    // Start is called before the first frame update
    void Start()
    {
        actualComp = PlayerPrefs.GetInt("ActualCompetence");
        this.GetComponent<Image>().sprite = rules[actualComp - 1];
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
