using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonAnswer : MonoBehaviour
{

    [SerializeField] private int answerID;

    private GameController game_controller;

    // Start is called before the first frame update
    void Start()
    {
        game_controller = GameObject.Find("GameController").GetComponent<GameController>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnMouseUpAsButton()
    {
        //SendAnswerToGameController(answerID);
    }

    void SendAnswerToGameController(string a)
    {
        game_controller.getAnswerFromButtons(a);
    }
}
