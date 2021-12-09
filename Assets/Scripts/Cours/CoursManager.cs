using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class CoursManager : MonoBehaviour
{
    public Sprite[] imgCours;
    public string[] titleCours;
    public Image nextFrame;
    public Image previousFrame;
    public Image backMenuFrame;
    public Image coursFrame;
    public Image validateFrame;
    public TextMeshProUGUI titleFrame;

    private int lvlComp = 0;

    private int actualComp = 1;

    int actualScreen = 0;
    // Start is called before the first frame update
    void Start()
    {
        //PlayerPrefs.SetInt("ActualCompetence", 1);
        LoadCours();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void LoadCours(){
        actualComp = PlayerPrefs.GetInt("ActualCompetence");
        titleFrame.text = titleCours[actualComp - 1];
        previousFrame.gameObject.SetActive(false);
        nextFrame.gameObject.SetActive(true);
        validateFrame.gameObject.SetActive(false);
        lvlComp = PlayerPrefs.GetInt("LvlComp" + actualComp);


    }

    public void NextFrame(){
        actualScreen += 1;
        coursFrame.sprite = imgCours[(actualComp-1) * 2 + actualScreen];
        previousFrame.gameObject.SetActive(true);
        nextFrame.gameObject.SetActive(false);
        validateFrame.gameObject.SetActive(true);

        
    }

    public void PreviousFrame(){
        actualScreen -= 1;
        coursFrame.sprite = imgCours[(actualComp-1) * 2 + actualScreen];
        previousFrame.gameObject.SetActive(false);
        nextFrame.gameObject.SetActive(true);
        validateFrame.gameObject.SetActive(false);
    }

    public void GoToScene(int id){
        SceneManager.LoadScene(2);
    }

    public void EndCours(){
        SceneManager.LoadScene(2);
        if (lvlComp < 1){
            PlayerPrefs.SetInt("LvlComp"+actualComp, 1);
        }
    }
}
