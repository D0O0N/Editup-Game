using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CollisionDetectionV2 : MonoBehaviour
{
    public Text txtScore;
    public GameObject spawner;
    public GameObject chara;
    public GameObject endScreen;

    int score = 0;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponent<BallBehaviorV2>().type == other.gameObject.GetComponent<BallBehaviorV2>().rep)
        {
            score = score + 1;
            Destroy(other.gameObject);
        } else {
            score = 0;
            Destroy(other.gameObject);
        }
        if (other.gameObject.name == "WhateverYouWant")
        {
           //Possibility of adding mor behaviors here
        }

        txtScore.text = "Score : " + score + " sur 8";

        if (score == 8) {
            spawner.GetComponent<SpawnObjectV2>().end = true;
            chara.SetActive(false);
            endScreen.SetActive(true);
        }
    }
}
