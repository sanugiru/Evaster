using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameStartMenu : MonoBehaviour
{
    [Header("UI Pages")]
    public GameObject mainMenu;
    //public GameObject options;
    public GameObject about;

    [Header("Main Menu Buttons")]
    public Button storage1Button;
    public Button storage2Button;
    public Button storage3Button;
    public Button storage4Button;
    public Button officeButton;
    public Button earthquakeLow;
    public Button earthquakeMedium;
    public Button earthquakeHigh;
    public Button aboutButton;
    public Button quitButton;
    

    public List<Button> returnButtons;

    // Start is called before the first frame update
    void Start()
    {
        EnableMainMenu();

        //Hook events
        storage1Button.onClick.AddListener(()=>StartGame(1));
        storage2Button.onClick.AddListener(() => StartGame(2));
        storage3Button.onClick.AddListener(() => StartGame(3));
        storage4Button.onClick.AddListener(() => StartGame(4));
        officeButton.onClick.AddListener(() => StartGame(5));
        earthquakeLow.onClick.AddListener(()=>StartGame(6));
        earthquakeMedium.onClick.AddListener(()=>StartGame(7));
        earthquakeHigh.onClick.AddListener(()=>StartGame(8));
        //optionButton.onClick.AddListener(EnableOption);
        aboutButton.onClick.AddListener(EnableAbout);
        quitButton.onClick.AddListener(QuitGame);

        foreach (var item in returnButtons)
        {
            item.onClick.AddListener(EnableMainMenu);
        }
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void StartGame(int index)
    {
        HideAll();
        SceneTransitionManager.singleton.GoToSceneAsync(index);
    }

    //public void StartBGame()
    //{
    //    HideAll();
    //    SceneTransitionManager.singleton.GoToSceneAsync(2);
    //}

    public void HideAll()
    {
        mainMenu.SetActive(false);
        //options.SetActive(false);
        about.SetActive(false);
    }

    public void EnableMainMenu()
    {
        mainMenu.SetActive(true);
        //options.SetActive(false);
        about.SetActive(false);
    }
    public void EnableOption()
    {
        mainMenu.SetActive(false);
        //options.SetActive(true);
        about.SetActive(false);
    }
    public void EnableAbout()
    {
        mainMenu.SetActive(false);
        //options.SetActive(false);
        about.SetActive(true);
    }
}
