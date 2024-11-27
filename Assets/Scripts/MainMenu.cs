using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    // Start is called before the first frame update
    
    public void StartGame() 
    {
        SceneManager.LoadScene("Level 1");
        
    }

    public void selectLevel() 
    {
        SceneManager.LoadScene("SelectLevel");
    }

    public void selectLevel2()
    {
        SceneManager.LoadScene("Level 2");
    }

    public void selectLevel3()
    {
        SceneManager.LoadScene("Level 3");
    }

    public void returnToMenu() 
    {
        SceneManager.LoadScene("Menu");
    }

    public void quitGame() 
    {
        Application.Quit(); 
    }

    public void goToInstructions() 
    {
        SceneManager.LoadScene("InstructionScene");
    }

    public void selectBossLevel() 
    {
        SceneManager.LoadScene("BossFight");
    }

   
}

