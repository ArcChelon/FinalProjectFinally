using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonFunctions : MonoBehaviour
{

    public void OnLevelOneButtonClick()
    {
        //ButtonClick();
        SceneManager.LoadScene("Level_1");
        Time.timeScale = 1;

    }

    public void OnLevelTwoButtonClick()
    {
        //ButtonClick();
        SceneManager.LoadScene("Level_2");
        Time.timeScale = 1;

    }
    public void OnLevelThreeButtonClick()
    {
        //ButtonClick();
        SceneManager.LoadScene("Level_3");
        Time.timeScale = 1;

    }

    public void OnNextLevelButtonClick()
    {
        //ButtonClick();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        Time.timeScale = 1;

    }

    public void OnLevelSelectButtonClick()
    {
        //ButtonClick();
        SceneManager.LoadScene("Level_Select");
        Time.timeScale = 1;

    }
    public void OnHelpButtonClick()
    {
        //ButtonClick();
        SceneManager.LoadScene("Help");

    }
    public void OnCreditsButtonClick()
    {
        //ButtonClick();
        SceneManager.LoadScene("Credits");

    }
    public void OnMainMenuButtonClick()
    {
        //ButtonClick();
        SceneManager.LoadScene("Menu");

    }
    public void OnQuitButtonClick()
    {
        //ButtonClick();
        print("Click");
        Application.Quit();

    }
    public void OnClickRestartButtton()
    {
        SceneManager.LoadScene("Level_Select");
    }
   
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
