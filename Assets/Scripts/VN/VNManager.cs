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
    public GameObject endLevel;
    private VN vn;
    private int VNnb = 0;
    private int cat = 0;
    // Start is called before the first frame update
    void Start()
    {
        vn = JsonUtility.FromJson<VN>(fichiersJson[VNnb].text);
        /*
        foreach (Categorie categorie in vn.categories)
        {
            Debug.Log(categorie.NomCatégorie);
        }
        */
        LoadCat(0);
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void LoadCat(int nbCat)
    {
        cat = nbCat;
        foreach (Transform child in questionsParent)
            Destroy(child.gameObject);
        foreach (Question question in vn.categories[cat].questions)
        {
            AddQuestion(question, false);
            //Debug.Log(question.question);
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
            popup.GetComponentInChildren<TextMeshProUGUI>().text = vn.categories[cat].analyseFinCat;
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
        if (debloq)
        {
            QuestSelect(id,vn.categories[cat].questionsDéblocables);
        } else
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
        Debug.Log("Gagné!");
        endLevel.GetComponentInChildren<TextMeshProUGUI>().text = vn.TexteFin;
        endLevel.SetActive(true);
    }

    private void GameOver(string raison)
    {
        popup.GetComponentInChildren<TextMeshProUGUI>().text = raison;
        popup.SetActive(true);
    }

    public void HidePopup()
    {
        popup.SetActive(false);
    }
}
