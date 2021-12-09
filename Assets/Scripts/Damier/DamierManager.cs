using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class DamierManager : MonoBehaviour
{
    //public TextMeshProUGUI textTime;
    public TextMeshProUGUI textQuestion;
    public TextMeshProUGUI textEnd;
    public GameObject[] linePlacement;
    

    public GameObject endLevelPopup;    // Popup de fin de lvl
    private LineScript nextNextLine;      // Futur line non interactible, seulement visuel
    private LineScript nextLine;          // Libe où le player va pouvoir aller
    private LineScript playerLine;        // Line où se situe le player
    private Transform targetLine;
    public GameObject line;
    public Transform lineGenerator;     // Emplacement spanw line

    private Transform target;
    public Transform player;

    private float nextActionTime = 0.0f;
    //private float period = 0.02f;                                                                                                                                                                           
    string data = "Quelles sont les raisons de votre voyage ?;Fermée; Ouverte; 1 _Y êtes vous-déjà allé ?;Fermée; Ouverte;0_Pourquoi dites vous cela ?;Fermée; Ouverte;1_Que lui reprochez-vous ?;Fermée; Ouverte;1_Quel est votre budget ?;Fermée; Ouverte;0_Que souhaitez-vous faire ?;Fermée; Ouverte;1_Quand partez-vous ?;Fermée; Ouverte;0_Préférez-vous la mer ou la montagne ?;Fermée; Ouverte;0";
    
    string question;
    List<string> questions =  new List<string>();
    int goodAnswer;
    List<int> goodAnswers =  new List<int>();

    int actualQuestion = 0;

    string[] answer;
    int score = 0;
    public int endScore = 8;
    private int actualComp;

    //float startTime = 10;
    //double timeLeft;
    //bool inGame = true;

    AudioSource src;
    public AudioClip srcGood;
    public AudioClip srcBad;
 
    // Start is called before the first frame update
    void Start()
    {
        src = GetComponent<AudioSource>();
       actualComp = actualComp = PlayerPrefs.GetInt("ActualCompetence");
       StartLevel();
       //player = GameObject.FindWithTag("Player").transform;
       
       
        
    }

    public void StartLevel(){
        foreach (Transform child in this.gameObject.transform)
            Destroy(child.gameObject);
        
        score = 0;
        nextActionTime = Time.time;
        //inGame = true;
        endLevelPopup.SetActive(false);
        //timeLeft = startTime;
        // Reset
        questions =  new List<string>();
        actualQuestion = 0;
        //
        ReadData(data);
        SpawnLevel();
        UpdateVisual();
        //StartTimer(1);
    }


    public void SpawnLevel(){
        nextNextLine = InstanceLine();
        nextLine = InstanceLine();
        nextLine.GoDown();
        nextLine.isInteract = true;
        playerLine = InstanceLine();
        playerLine.GoDown();
        playerLine.GoDown();

        target = playerLine.gameObject.transform;
        playerLine.gameObject.SetActive(false);

    }

    public void NextStep(){
        //move
        nextNextLine.GoDownSmooth();
        nextLine.GoDownSmooth();
        playerLine.Vanished();

        // Reassign
        playerLine = nextLine;
        nextLine = nextNextLine;
        nextNextLine = InstanceLine();

        // Button are interactible ?
        playerLine.isInteract = false;
        nextLine.isInteract = true;

        //nextLine.WriteButton(answer);
        playerLine.CleanButton();
        actualQuestion += 1;
        
        
        
        if (actualQuestion < questions.Count)
            UpdateVisual();
        else{
            actualQuestion = 0;
            UpdateVisual();
        }
        if (score >= endScore)
            EndLevel();
            
    }


    LineScript InstanceLine(){
        LineScript newLine = Instantiate(line, lineGenerator.transform.position, Quaternion.identity).GetComponent<LineScript>();
        //newLine.transform.SetParent(GameObject.FindGameObjectWithTag("Canvas").transform, false);
        newLine.isInteract = false;
        newLine.transform.SetParent(this.gameObject.transform, false);
        newLine.dManager = this;
        newLine.gameObject.transform.position = lineGenerator.position;
        newLine.WriteButton(answer);
        

        return newLine;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //Moves the GameObject from it's current position to destination over time


        player.position = Vector2.MoveTowards(player.position, target.position, 15);

        //UpdateTimeBar();
        
    }
    void Update(){
        /*

        if (inGame && Time.time > nextActionTime ) {
            UpdateTimeBar();
            nextActionTime += period;
            //timeLeft -= period;
            //textTime.text = Mathf.Ceil((float)timeLeft).ToString();
            //textTime.text = (Mathf.Round((float)(timeLeft * 10)) / 10).ToString();
            if (timeLeft < 0){
                EndLevel();
            }
        }
        */
    }

    // Split la donnée pour question / answer[] / goodAnswer
    void ReadData(string data){
        string[] splitSentence =  data.Split(char.Parse("_"));
        foreach (string sentence in splitSentence)
        {
            string[] splitData =  sentence.Split(char.Parse(";"));
            question = splitData[0];
            questions.Add(question);
            answer = new string [2]{ splitData[1], splitData[2]};;
            goodAnswer = int.Parse(splitData[3]);
            goodAnswers.Add(goodAnswer);
        }
        

    }

    // Update visual data
    void UpdateVisual(){
        textQuestion.text = questions[actualQuestion];
    }

    // Start Timer + Visual, numbrer of second
    void StartTimer(float startTime){
        HealthBarHandler.SetHealthBarValue(1f);
    }

    // Make choice
    public void MakeChoice(int choice){
        bool goodChoice = choice == goodAnswers[actualQuestion];
        EndQuestion(goodChoice);
    
        if (goodChoice)
        {
            nextLine.GoodAnswer(choice);
            src.clip = srcGood;
            src.Play();
        }
        else
        {
            src.clip = srcBad;
            src.Play();
            nextLine.WrongAnswer(choice);
        }
        
        target = nextLine.gameObject.transform.GetChild(choice).transform;
        NextStep();

    }

    // Question
    void EndQuestion(bool win){
        if (win){
            score += 1;
            //timeLeft += 1;
        }
        else
        {
            score = 0;
            //timeLeft -= 1;
        }
    }

    // Update visual Bar
    /*
    void UpdateTimeBar(){
        HealthBarHandler.SetHealthBarValue((float)(timeLeft / startTime));
        //HealthBarHandler.SetHealthBarValue(startTime / timeLeft);

    }
    */

    // 
    void EndLevel(){
        //inGame = false;
        ShowEndLevel();
    }
    void ShowEndLevel(){
        endLevelPopup.SetActive(true);
        textEnd.text = "Bravo vos avez trouvé "+score+" / " + questions.Count + "bonnes réponses.";
        Validate();
    }

    public void Validate(){
        PlayerPrefs.SetInt("LvlComp"+actualComp, 2);
    }

    
}
