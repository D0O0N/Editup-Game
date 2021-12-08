using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class SpawnObjectV2 : MonoBehaviour
{
    public float Speed = 5f;
    public float maxTime = 3f;
    public float minTime = 0f;
    public Rigidbody ball;
    float timeLeft = 1f;
    private int random;
    public UnityEngine.UI.Text Sentence;
    private string[,] data;
    public bool end = false;
    public Button btnMenu;

    // Start is called before the first frame update
    void Start()
    {
        //Sentence.text = "Bonjour";
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

        btnMenu.onClick.AddListener(goMenu);
    }

    // Update is called once per frame
    void Update()
    {
        if (!end) {
            timeLeft -= Time.deltaTime;
            if (timeLeft < 0)
            {
                Rigidbody clone;
                random = Random.Range(0, data.GetLength(0));
                clone = Instantiate(ball, transform.position + new Vector3(Random.Range(-5f, 5f), 0, 0), transform.rotation);
                clone.velocity = transform.TransformDirection(Vector3.down * Speed);
                clone.gameObject.GetComponent<BallBehavior>().type = data[random,1];
                Sentence.text = data[random,0];

                if (data[random, 1] == "F") {
                    clone.gameObject.GetComponent<SpriteRenderer>().color = Color.blue;
                    /*clone.gameObject.AddComponent<Text>();
                    clone.gameObject.GetComponent<Text>().text = "P";*/
                } else {
                    clone.gameObject.GetComponent<SpriteRenderer>().color = Color.green;
                }

                timeLeft = Random.Range(minTime, maxTime);
            }
        }
    }

    void goMenu() {
        SceneManager.LoadScene("MenuScene");
    }
}
