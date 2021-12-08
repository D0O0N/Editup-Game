using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class MenuCompManager : MonoBehaviour
{
    private int actualComp = 1;
    private int lvlComp = 0;

    public GameObject[] buttons;
    public GameObject rulePopup;
    
    // Start is called before the first frame update
    void Start()
    {
        rulePopup.SetActive(false);
        actualComp = PlayerPrefs.GetInt("ActualCompetence");
        LoadComp();
    }

    // Update is called once per frame
    void Update()
    {
       
    }

    void LoadComp(){
        lvlComp = PlayerPrefs.GetInt("LvlComp" + actualComp);
        for (int i = 0; i < lvlComp; i++)
        {
             buttons[i].GetComponent<LockButton>().Unlock();
        }

    }

    public void PopRules(){
        rulePopup.SetActive(true);
    }

    public void LoadGame(){
        switch (actualComp)
        {
        case 1:
            LoadScene(4);
            break;
        case 2:
            LoadScene(5);
            break;
        case 3:
            LoadScene(6);
            break;
        case 4:
            LoadScene(7);
            break;
        case 5:
            LoadScene(4);
            break;
        case 6:
            LoadScene(7);
            break;
        }
    }

    void LoadScene(int i){
        SceneManager.LoadScene(i);
    }
}
