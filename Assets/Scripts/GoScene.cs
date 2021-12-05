using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GoScene : MonoBehaviour
{
    [SerializeField] Object sceneToGo;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // Load a scene passed in params
    public void LoadScene(){
        SceneManager.LoadScene(sceneToGo.name);
    }
}
