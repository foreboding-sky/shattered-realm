using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    public GameObject settingsPanel;
    public void StartGame()
    {
        SceneManager.LoadScene(1);

    }
   public void ExitGame()
    {
        Debug.Log("Quitting");
        Application.Quit();
    }
    public void OpenSettings()
    {
        settingsPanel.SetActive(true);
    }
    public void CloseSettings()
    {
        settingsPanel.SetActive(false);
    }
}
