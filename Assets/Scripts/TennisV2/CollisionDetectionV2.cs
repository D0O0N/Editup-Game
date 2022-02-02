using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CollisionDetectionV2 : MonoBehaviour
{
    public TextMeshProUGUI txtScore;
    public GameObject spawner;
    public CharacterBehavior chara;
    public GameObject endScreen;
    public Animator character;
    public ParticleSystem particle;
    public ParticleSystem particle2;
    public Sprite SpriteAfter;

    int score = 0;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponent<BallBehaviorV2>().type == other.gameObject.GetComponent<BallBehaviorV2>().rep)
        {
            score = score + 1;
            particle.Play();
            Destroy(other.gameObject);
        } else {
            score = 0;
            Destroy(other.gameObject);
            character.SetTrigger("Sad");
        }
        if (other.gameObject.name == "WhateverYouWant")
        {
           //Possibility of adding mor behaviors here
        }

        txtScore.text = "Score : " + score + " sur 8";

        if (score == 8) {
            spawner.GetComponent<SpawnObjectV2>().stoop();
            chara.stoop();
            endScreen.SetActive(true);
        }
    }
}
