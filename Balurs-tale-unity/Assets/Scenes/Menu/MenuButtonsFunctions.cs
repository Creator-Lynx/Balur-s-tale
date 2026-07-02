using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuButtonsFunctions : MonoBehaviour
{
    public void ButtonStart()
    {
        //hide menu corrutine

        //async load game intro

        // for test simple load game scene
        SceneManager.LoadScene("Game");
    }

    [SerializeField] GameObject settingsLayer;
    public void ButtonSettings()
    {
        settingsLayer.SetActive(!settingsLayer.activeSelf);
    }

    public void ButtonExit()
    {
        //Hide menu corutine
        
        Application.Quit();
    }
}
