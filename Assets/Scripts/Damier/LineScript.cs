using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class LineScript : MonoBehaviour
{
    private List<Button> choices = new List<Button>();
    public int choice = 0;
    public DamierManager dManager;
    public bool isInteract = false;
    public int lineDistance = 340;
    private Vector3 goTo;
    public int lineIndex = 0;

    public TextMeshProUGUI[] textChoices;
    // Start is called before the first frame update
    void Start()
    {
        goTo = this.transform.position;
        
    }

    // Update is called once per frame
    void Update()
    {
        
        this.gameObject.transform.position = Vector3.MoveTowards(this.gameObject.transform.position, goTo, 1);
    }


    public void NotifyChoice(int choice){
        if (isInteract){
            dManager.MakeChoice(choice);
        }
        
    }

    public void GoDown(){
        this.gameObject.transform.position -= new Vector3(0,lineDistance,0);
        goTo = this.transform.position;
        //goTo = dManager.linePlacement[lineIndex].transform;
        lineIndex += 1;
    }
    public void GoDownSmooth(){

        //goTo = new Vector3(this.gameObject.transform.position.x , this.gameObject.transform.position.y - lineDistance, this.gameObject.transform.position.z);
        lineIndex += 1;
        goTo = dManager.linePlacement[lineIndex].transform.position;
        
        //this.transform.position = Vector2.MoveTowards(this.transform.position, goTo, 1);
        
    }
    public void GoUp(){
        this.transform.position += new Vector3(0,lineDistance,0);
    }

    public void Vanished(){
        Destroy(this.gameObject);
    }

    public void WriteButton(string[] texts){
        for (int i = 0; i < texts.Length; i++)
        {
            textChoices[i].text = texts[i];
        }
    }

    public void CleanButton(){
        for (int i = 0; i < textChoices.Length; i++)
        {
            textChoices[i].text = "";
        }
    }

    
    public void WrongAnswer(int index){
        textChoices[index].gameObject.transform.parent.GetComponent<Image>().color = Color.red;
    }
    public void GoodAnswer(int index){
        textChoices[index].gameObject.transform.parent.GetComponent<Image>().color = Color.green;
    }
}
