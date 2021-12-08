using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class NavigationButtons : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void GoToScene(int id)
    {
        SceneManager.LoadScene(id);
    }

    public void GoToScene(string id)
    {
        SceneManager.LoadScene(id);
    }

    public void QuitApplication()
    {
        Application.Quit();
    }
}
