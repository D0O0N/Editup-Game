using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnObject : MonoBehaviour
{

    public float Speed = 5f;
    public float maxTime = 3f;
    public float minTime = 0f;
    public Rigidbody ball;
    float timeLeft = 1f;
    private int random;
    public UnityEngine.UI.Text Sentence;
    private string[,] data;

    // Start is called before the first frame update
    void Start()
    {
        Sentence.text = "Bonjour";
        data = new string[,] {
                { "10 jours de délai c’est trop long : notre salon est mardi", "R"}, 
                {"Votre documentation n’est pas claire", "P"}, 
                {"Il faut que je réfléchisse", "P"},
                {"Nous sommes plusieurs à décider", "P"},
                {"Notre budget fourniture est limité à 10K€ par mois", "R"},
                {"Nous serons en congés cette semaine", "R"},
                {"Ce n’est pas moi qui décide", "P"},
            };
    }

    // Update is called once per frame
    void Update()
    {
        timeLeft -= Time.deltaTime;
        if (timeLeft < 0)
        {
            Rigidbody clone;
            random = Random.Range(0, data.GetLength(0));
            clone = Instantiate(ball, transform.position + new Vector3(Random.Range(-5f, 5f), 0, 0), transform.rotation);
            clone.velocity = transform.TransformDirection(Vector3.down * Speed);
            clone.gameObject.GetComponent<BallBehavior>().type = data[random,1];
            Sentence.text = data[random,0];
            timeLeft = Random.Range(minTime, maxTime);
        }
    }
}
