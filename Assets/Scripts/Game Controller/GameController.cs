using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{

    [SerializeField] private string[] questionsArray;
    [SerializeField] private string[] answerArray;
    [SerializeField] private Sprite[] charactersArray;

    [SerializeField] private GameObject character;
    [SerializeField] private Text questionText;
    [SerializeField] private Text happyClientsText;
    [SerializeField] private Text sadClientsText;
    [SerializeField] private TextAsset jsonFile;

    //[SerializeField] private GameObject clock;

    private string userAnswer;

    private int lastQuestionAsked = -1;
    private int lastCharacterDisplayed = -1;
    private int randomQID = -1;
    private int randomCharacter = -1;

    private List<string> questionsList = new List<string>();
    private List<string> answersList = new List<string>();

    private string lastAnswerFromList = "";

    private int happyClients = 0;
    private int sadClients = 0;

    //private string jsonFilePath = "Assets/Scripts/JSON/QAlist.json";


    // Start is called before the first frame update
    void Start()
    {
        InitialisatioAndCreationJSONFile();
        FillQuestionsList();
        FillAnswersList();

        DisplayRandomCharacter();
        DisplayRandomQuestionV2();

        DisplayPoints(happyClients, sadClients);
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void CheckAnswer()
    {
        string answer = answerArray[lastQuestionAsked];

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

        DisplayPoints(happyClients, sadClients);
    }


    private void CheckAnswerV2()
    {
        if (userAnswer == lastAnswerFromList)
        {
            happyClients++;
            DisplayRandomQuestionV2();
        }
        else
        {
            //sadClients++;
            sadClients = 0;
            happyClients = 0;

            questionsList.Clear(); //resetList
            answersList.Clear();

            FillQuestionsList();
            FillAnswersList();

            DisplayRandomQuestionV2();
        }

        DisplayRandomCharacter();
        DisplayPoints(happyClients, sadClients);
    }

    private void InitialisatioAndCreationJSONFile()
    {
       
       
        if (jsonFile!= null)
        {
            // File exists, load Q&A's
            ReadJSON();
        }
        else
        {
            // File does not exist. // This could mean it was deleted or has not been created yet. // Write new json file with default questions and answer form editor
            //WriteJSON();
        }
    }

    private void FillQuestionsList()
    {
        for (int i = 0; i < questionsArray.Length; i++)
        {
            questionsList.Add(questionsArray[i]);
        }
    }

    private void FillAnswersList()
    {
        for (int i = 0; i < answerArray.Length; i++)
        {
            answersList.Add(answerArray[i]);
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
        do
        {
            randomCharacter = Random.Range(0, charactersArray.Length);
        }
        while (lastCharacterDisplayed == randomCharacter);

        character.GetComponent<SpriteRenderer>().sprite = charactersArray[randomCharacter];
    }

    private void DisplayRandomQuestion()
    {
        do
        {
            randomQID = Random.Range(0, questionsArray.Length);
        }
        while (lastQuestionAsked == randomQID);

        questionText.text = questionsArray[randomQID];
        lastQuestionAsked = randomQID;
    }


    private void DisplayRandomQuestionV2()
    {
        int questionsCount = questionsList.Count;

        if (questionsCount > 0)
        {
            int qID = Random.Range(0, questionsList.Count);
            questionText.text = questionsList[qID];
            lastAnswerFromList = answersList[qID];

            answersList.RemoveAt(qID);
            questionsList.RemoveAt(qID);
        }
        else
        {
            //gameOver
            Debug.Log("GameOver");
            questionText.text = "GameOver";
        }
    }

    //private void WriteJSON()
    //{
    //    QuestionsAnswers QAdata = new QuestionsAnswers();
    //    QAdata.questions = questionsArray;
    //    QAdata.answers = answerArray;

    //    string json = JsonUtility.ToJson(QAdata);
    //    Debug.Log(json);

    //    File.WriteAllText(jsonFile, json);
    //}

    private void ReadJSON()
    {
        QuestionsAnswers QAdata = new QuestionsAnswers();

        //string jsonText = File.ReadAllText(jsonFile);
        JsonUtility.FromJsonOverwrite(jsonFile.text, QAdata);

        questionsArray = QAdata.questions;
        answerArray = QAdata.answers;
    }

    public void getAnswerFromButtons(string a)
    {
        userAnswer = a;
        Debug.Log($"got answer {a} from user");

        //CheckAnswer();
        CheckAnswerV2();
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