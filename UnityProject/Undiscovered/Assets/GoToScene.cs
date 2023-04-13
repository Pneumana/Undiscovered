using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GoToScene : MonoBehaviour
{
    public string destiniation;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    public void GoToNewScene()
    {
        //UpdateManager.instance.takenIdol = false;
        SceneManager.LoadScene(destiniation, LoadSceneMode.Single);
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
