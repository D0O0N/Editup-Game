using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;



public class SpawnObjectV2 : MonoBehaviour
{
    public float Speed = 5f;
    public float maxTime = 3f;
    public float minTime = 0f;
    public Rigidbody ball;
    float timeLeft = 1f;
    private int random;
    public TextMeshProUGUI Sentence;
    private string[,] data;
    private bool stopGame = false;
    public GameObject spawn1;
    public GameObject spawn2;
    public Sprite spriteBallF;
    public Sprite spriteBallI;
    //public Button btnMenu;
    public Button btnMenu2;

    // Start is called before the first frame update
    void Start()
    {
        data = new string[,] {
                {"Tu es toujours absente", "I"}, 
                {"Il n'aime pas les réunions", "I"}, 
                {"Il est arrivé à 10 heures 30", "F"},
                {"Il n'a pas invité Agnés", "F"},
                {"Il n'appelle jamais", "I"},
                {"Il n'a pas apporté son contrat", "F"},
                {"Il n'a jamais ses affaires sur lui", "I"},
                {"Il n'est jamais là", "I"}
            };

        //btnMenu.onClick.AddListener(goMenu);
        btnMenu2.onClick.AddListener(goMenu);
    }

    public void stoop()
    {
        stopGame = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (!stopGame) {
            timeLeft -= Time.deltaTime;
            if (timeLeft < 0)
            {
                Rigidbody clone;
                Rigidbody clone2;
                random = Random.Range(0, data.GetLength(0));

                Vector3 pos1 = new Vector3(Random.Range(-5f, 5f), 0, 0);
                Vector3 pos2 = new Vector3(Random.Range(-5f, 5f), 0, 0);

                clone = Instantiate(ball, transform.position + pos1, transform.rotation);
                clone2 = Instantiate(ball, transform.position + pos2, transform.rotation);

                clone.transform.GetChild(0).transform.Rotate(new Vector3(0, 0, Random.Range(0, 360)));
                clone2.transform.GetChild(0).transform.Rotate(new Vector3(0, 0, Random.Range(0, 360)));

                clone.gameObject.GetComponent<BallBehaviorV2>().startTimer();
                clone2.gameObject.GetComponent<BallBehaviorV2>().startTimer();

                if (data[random, 1] == "F") {
                    clone.transform.GetChild(0).GetComponent<SpriteRenderer>().sprite = spriteBallF;
                    clone.gameObject.GetComponent<BallBehaviorV2>().type = "F";
                    clone.gameObject.GetComponent<BallBehaviorV2>().rep = "F";
                    clone2.transform.GetChild(0).GetComponent<SpriteRenderer>().sprite = spriteBallI;
                    clone2.gameObject.GetComponent<BallBehaviorV2>().type = "I";
                    clone2.gameObject.GetComponent<BallBehaviorV2>().rep = "F";
                } else {
                    clone.transform.GetChild(0).GetComponent<SpriteRenderer>().sprite = spriteBallI;
                    clone.gameObject.GetComponent<BallBehaviorV2>().type = "I";
                    clone.gameObject.GetComponent<BallBehaviorV2>().rep = "I";
                    clone2.transform.GetChild(0).GetComponent<SpriteRenderer>().sprite = spriteBallF;
                    clone2.gameObject.GetComponent<BallBehaviorV2>().type = "F";
                    clone2.gameObject.GetComponent<BallBehaviorV2>().rep = "I";
                }

                Sentence.text = data[random, 0];
                timeLeft = Random.Range(minTime, maxTime);
            }
        }
    }

    void goMenu() {
        SceneManager.LoadScene("Menu Principal");
    }
}
