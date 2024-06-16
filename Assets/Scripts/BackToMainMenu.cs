using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class BackToMainMenu : MonoBehaviour
{
    public Button backButton;
    public Button quitButton;
    void Start()
    {
        backButton.onClick.AddListener(BackToMain);
        quitButton.onClick.AddListener(QuitGame);
    }
    public void BackToMain()
    {
        SceneManager.LoadSceneAsync(0, LoadSceneMode.Single);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
