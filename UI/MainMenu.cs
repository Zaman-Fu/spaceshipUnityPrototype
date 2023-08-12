using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartGame()
    {
        SceneManager.LoadScene(1);
    }

    public void MissionList()
    {
        //Not implemented
    }

    public void GameOptions()
    {
        //Implemented through the editor
    }
    public void ActivateKeyboardControls()
    {

    }

    public void ActivateGamepadControls()
    {

    }

    public void Instructions()
    {
        //Implemented through the editor
    }
    public void QuitGame()
    {
        Application.Quit();
    }

   

    
}
