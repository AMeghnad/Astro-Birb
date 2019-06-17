using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GUIManager : MonoBehaviour
{
    public bool showOptions, showMainMenu;
    public string saveData, gameData;
    public GameObject mainMenu, options;


    void Awake()
    {
        showOptions = false;
        showMainMenu = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (showMainMenu)
            showOptions = false;

        if (showOptions)
            showMainMenu = false;
    }

    void Play()
    {
        //if (saveData != null)
        {
            showMainMenu = false;
            showOptions = false;
        }
    }

    void ShowOptions()
    {
        ToggleOptions();
    }

    public bool ToggleMenu()
    {
        if (showMainMenu)
        {
            mainMenu.SetActive(true);
            options.SetActive(false);
            // Pause active game
            return true;
        }
        else
        {
            mainMenu.SetActive(false);
            return false;
        }
    }

    public bool ToggleOptions()
    {
        if (showOptions)
        {
            mainMenu.SetActive(false);
            options.SetActive(true);
            return false;
        }
        else
        {
            options.SetActive(false);
            return true;
        }
    }

    void Pause()
    {
        showOptions = true;
    }

    void Exit()
    {
        showMainMenu = true;
    }

    void Quit()
    {
        Application.Quit();
    }

    void Save()
    {
        // Set Player Prefs
    }

    void Load()
    {
        // Get Player Prefs
    }
}
