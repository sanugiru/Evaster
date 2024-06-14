using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitButton : MonoBehaviour
{
    public Collider buttonCollider;
    public Collider playerRightHandCollider;
    public Collider playerLeftHandCollider;
    public GameObject warningScreen;
    public int isPressed = 0;
    float buttonPressCooldown = 1f;
    float buttonPressTimer = 0f;

    // Start is called before the first frame update
    void Start()
    {
        HideMenu();
    }

    // Update is called once per frame
    void Update()
    {
        if (buttonPressTimer > 0)
        {
            buttonPressTimer -= Time.deltaTime;
        }

        if (buttonCollider.bounds.Intersects(playerRightHandCollider.bounds) || buttonCollider.bounds.Intersects(playerLeftHandCollider.bounds))
        {
            if (buttonPressTimer <= 0)
            {
                isPressed += 1;
                if (isPressed == 1)
                {   
                    ShowMenu();
                }
                else if (isPressed == 2)
                {
                    BackToMainMenu();
                }
                buttonPressTimer = buttonPressCooldown;
            }
        }
    }

    void ShowMenu()
    {
        warningScreen.SetActive(true);
    }

    void HideMenu()
    {
        warningScreen.SetActive(false);
    }

    void BackToMainMenu()
    {   
        HideMenu();
        SceneTransitionManager.singleton.GoToSceneAsync(0);
    }

}
