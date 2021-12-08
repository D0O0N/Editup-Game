using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class VNManager : MonoBehaviour
{
    public TextAsset[] fichiersJson;
    public GameObject prefabButtonQuestion;
    public Transform questionsParent;
    public TextMeshProUGUI textReponse;
    public GameObject popup;
    public TextMeshProUGUI popupTitle;
    public TextMeshProUGUI popupText;
    public GameObject endLevel;
    public GameObject levelChoice;
    public Transform VNParent;
    public TextMeshProUGUI titreVN;
    public TextMeshProUGUI nomPerso;
    public TextMeshProUGUI descriptionVN;
    public Button buttonStartVN;
    public TextMeshProUGUI actionPointsTextUI;
    public GoScene goMenu;
    public Image personnage;
    public Sprite[] chatellaineEmotions;
    public Sprite[] picEmotions;
    private VN vn;
    private int cat = 0;
    private int actionPoints;
    private string msgZeroActionPoint = "Vous n'avez plus de points d'actions";
    private Sprite[] emotions;
    // Start is called before the first frame update
    void Start()
    {
        SearchVN();
        //LoadVN(nb);
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void SearchVN()
    {
        foreach (TextAsset fichier in fichiersJson)
        {
            VN jeu = JsonUtility.FromJson<VN>(fichier.text);
            GameObject button = Instantiate(prefabButtonQuestion);
            button.transform.SetParent(VNParent);
            button.name = jeu.intro.titre;
            button.GetComponentInChildren<TextMeshProUGUI>().text = jeu.intro.titre;
            button.GetComponent<Button>().onClick.AddListener(() => ViewDescVN(jeu));
        }
    }

    private void ViewDescVN(VN v)
    {
        titreVN.text = v.intro.titre;
        nomPerso.text = v.intro.client;
        descriptionVN.text = v.intro.description;
        buttonStartVN.GetComponent<Button>().onClick.AddListener(() => LoadVN(v));
    }

    private void LoadVN(VN v)
    {
        vn = v;
        actionPoints = vn.intro.actionPoints;
        actionPointsTextUI.text = ""+actionPoints;
        switch (vn.intro.client)
        {
            case "Chatellaine":
                emotions = chatellaineEmotions;
                break;
            
            case "Pic":
                emotions = picEmotions;
                break;

            default:
            break;
        }
        LoadCat(0);
        levelChoice.SetActive(false);
    }

    private void LoadVN(int nb)
    {
        vn = JsonUtility.FromJson<VN>(fichiersJson[nb].text);
        actionPoints = vn.intro.actionPoints;
        LoadCat(0);
    }

    private void LoadCat(int nbCat)
    {
        cat = nbCat;
        foreach (Transform child in questionsParent)
            Destroy(child.gameObject);
        foreach (Question question in vn.categories[cat].questions)
        {
            AddQuestion(question, false);
        }
    }

    private void AddQuestion(Question question, bool QuestDebloq)
    {
        GameObject button = Instantiate(prefabButtonQuestion);
        button.transform.SetParent(questionsParent);
        button.name = question.idQ;
        button.GetComponentInChildren<TextMeshProUGUI>().text = question.question;
        button.GetComponent<Button>().onClick.AddListener(() => QuestSelect(question.idQ, QuestDebloq));
    }

    private void NextCat()
    {
        if (cat != 0)
        {
            popupTitle.text = "";
            popupText.text = vn.categories[cat].analyseFinCat;
            popup.SetActive(true);
        }
        cat += 1;
        try
        {
            LoadCat(cat);
        }
        catch (System.Exception)
        {
            FinPartie();
        }
    }

    private void QuestSelect(string id, bool debloq)
    {
        actionPoints--;
        actionPointsTextUI.text = ""+actionPoints;
        if (debloq)
        {
            QuestSelect(id, vn.categories[cat].questionsDéblocables);
        }
        else
        {
            QuestSelect(id, vn.categories[cat].questions);
        }
    }

    private void QuestSelect(string id, Question[] quest)
    {
        foreach (Question question in quest)
        {
            if (question.idQ.Equals(id))
            {
                textReponse.text = question.réponse;
                int nbEmotion = question.posture;
                personnage.sprite = emotions[nbEmotion];
                switch (question.résultat.typeRes)
                {
                    case 0:
                        Destroy(questionsParent.transform.Find(question.idQ).gameObject);
                        break;

                    case 1:
                        NextCat();
                        break;

                    case 2:
                        Destroy(questionsParent.transform.Find(question.idQ).gameObject);
                        DebloqQuest(question.résultat.questDébloq);
                        break;

                    case 3:
                        GameOver(question.résultat.raisonGO);
                        break;

                    case 9:
                        FinPartie();
                        break;

                    default:
                        break;
                }
            }
        }
        if (actionPoints<1)
        {
            GameOver(msgZeroActionPoint);
        }
    }

    private void DebloqQuest(questDébloq[] questions)
    {
        foreach (Question question in vn.categories[cat].questionsDéblocables)
        {
            foreach (questDébloq item in questions)
            {
                if (question.idQ.Equals(item.idQ))
                {
                    AddQuestion(question, true);
                }
            }
        }
    }

    private void FinPartie()
    {
        endLevel.GetComponentInChildren<TextMeshProUGUI>().text = vn.TexteFin;
        endLevel.SetActive(true);
    }

    private void GameOver(string raison)
    {
        popupTitle.text = "GAME OVER";
        popupText.text = raison;
        popup.GetComponentInChildren<Button>().onClick.AddListener(() => goMenu.LoadScene());
        popup.GetComponentInChildren<Button>().GetComponentInChildren<TextMeshProUGUI>().text = "Quitter";
        popup.SetActive(true);
    }

    public void HidePopup()
    {
        popup.SetActive(false);
    }
}
