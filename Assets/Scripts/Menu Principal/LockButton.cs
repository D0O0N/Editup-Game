using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LockButton : MonoBehaviour
{
    private Button button;
    public GameObject locker;
    // Start is called before the first frame update
    void Start()
    {
        button = this.GetComponent<Button>(); 
        Lock();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Lock(){
        /*ColorBlock cb = button.colors;
        cb.normalColor = Color.grey;
        button.colors = cb;*/
        locker.SetActive(true);
        button.interactable = false;
    }

    public void Unlock(){
        locker.SetActive(false);
        button.interactable = true;
    }
    
}
