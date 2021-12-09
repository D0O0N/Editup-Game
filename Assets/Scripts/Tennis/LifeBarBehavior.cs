using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LifeBarBehavior : MonoBehaviour
{

    public float decreaseSpeed = 0.01f;
    private Animator animator;
    public GameObject spawner;
    public GameObject character;
    public GameObject winScreen;

    public int actualComp;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        actualComp = actualComp = PlayerPrefs.GetInt("ActualCompetence");
    }

    // Update is called once per frame
    void Update()
    {
        float currentValue = animator.GetFloat("Status");
        animator.SetFloat("Status", currentValue - Time.deltaTime * decreaseSpeed);
        if(currentValue == 1f)
        {
            spawner.GetComponent<SpawnObject>().stoop();
            character.GetComponent<CharacterBehavior>().stoop();
            winScreen.SetActive(true);
            PlayerPrefs.SetInt("LvlComp"+actualComp, 2);

        }
        //Method to lose would look like this, but I dunno if this is nessessary or not
        /*if (currentValue < 0f)
        {
            spawner.GetComponent<SpawnObject>().stoop();
        }
        */

    }
}
