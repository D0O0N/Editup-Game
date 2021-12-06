using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{

    [SerializeField] private string[] questionsList;
    [SerializeField] private string[] answerList;
    [SerializeField] private Sprite[] charactersList;

    [SerializeField] private GameObject character;
    [SerializeField] private Text questionText;
    [SerializeField] private Text happyClientsText;
    [SerializeField] private Text sadClientsText;

    //[SerializeField] private GameObject clock;

    private string userAnswer;

    private int lastQuestionAsked = -1;
    private int randomQID = -1;
    
    private int happyClients = 0;
    private int sadClients = 0;

    private string jsonFilePath = "Assets/Scripts/JSON/QAlist.json";


    // Start is called before the first frame update
    void Start()
    {
        InitialisatioAndCreationJSONFile();
        DisplayRandomCharacter();
        DisplayRandomQuestion();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void getAnswerFromButtons(string a)
    {
        userAnswer = a;
        Debug.Log($"got answer {a} from user");

        CheckAnswer();
        DisplayRandomCharacter();
    }

    private void CheckAnswer()
    {
        string answer = answerList[lastQuestionAsked];

        if (userAnswer == answer)
        {
            happyClients++;            
            DisplayRandomQuestion();

        }
        else
        {
            sadClients++;
            DisplayRandomQuestion();
        }
        
        DisplayPoints(happyClients,sadClients);
    }

    private void InitialisatioAndCreationJSONFile()
    {
        if (File.Exists(jsonFilePath))
        {
            // File exists, load Q&A's
            ReadJSON();
        }
        else
        {
            // File does not exist. // This could mean it was deleted or has not been created yet. // Write new json file with default questions and answer form editor

            WriteJSON();
        }
    }

    private void DisplayPoints(int hc, int sc)
    {
        string mssg = $"Clients satisfaits: {hc}";
        happyClientsText.text = mssg;

        mssg = $"Clients decus: {sc}";
        sadClientsText.text = mssg;
    }

    private void DisplayRandomCharacter()
    {
        int randomCharacter = Random.Range(0, charactersList.Length);
        character.GetComponent<SpriteRenderer>().sprite = charactersList[randomCharacter];
    }

    private void DisplayRandomQuestion()
    {
        do
        {
            randomQID = Random.Range(0, questionsList.Length);
        }
        while (lastQuestionAsked == randomQID);
        
        questionText.text = questionsList[randomQID];
        lastQuestionAsked = randomQID;
    }

    private void WriteJSON()
    {   
        QuestionsAnswers QAdata = new QuestionsAnswers();
        QAdata.questions = questionsList;
        QAdata.answers = answerList;

        string json = JsonUtility.ToJson(QAdata);
        Debug.Log(json);

        File.WriteAllText(jsonFilePath, json);

        //{"caseCollidersArray":[{"name":"moboPlace","state":"case1","position":{"x":-4.5,"y":1.5},"collSizeArray":{"x":3.240000009536743,"y":4.0}}]}
    }

    private void ReadJSON()
    {
        QuestionsAnswers QAdata = new QuestionsAnswers();

        string jsonText = File.ReadAllText(jsonFilePath);
        JsonUtility.FromJsonOverwrite(jsonText, QAdata);

        questionsList = QAdata.questions;
        answerList = QAdata.answers;
    }    

    [System.Serializable]
    public class QuestionsAnswers
    {
        public string[] questions;
        public string[] answers;

        // JSON format:
        // {"question":["question 1","question 2","question 3"],"answer":[0,1,2]}
    }
}