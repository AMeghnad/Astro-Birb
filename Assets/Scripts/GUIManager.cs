using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GUI_Manager : MonoBehaviour
{
    public int showUI;
    public string saveData, gameData;
    public GameObject mainMenu, options, gameUI;
    public int currentWave, currentHealth, currentAmmo;


    void Awake()
    {
        showUI = 1;
    }

    // Update is called once per frame
    void Update()
    {
        SwitchUI();
    }

    void SwitchUI()
    {
        switch (showUI)
        {
            default:
                break;

            case 1:
                mainMenu.SetActive(true);
                options.SetActive(false);
                gameUI.SetActive(false);
                break;
            case 2:
                mainMenu.SetActive(false);
                options.SetActive(true);
                gameUI.SetActive(false);
                break;
            case 3:
                mainMenu.SetActive(false);
                options.SetActive(false);
                gameUI.SetActive(true);
                break;
        }
    }

    public void Play()
    {
        //Load();
        showUI = 3;
    }

    public void NewGame()
    {
        PlayerPrefs.SetInt("wave", 0);
        PlayerPrefs.SetInt("health", 100);
        PlayerPrefs.SetInt("ammo", 100);
        showUI = 3;
    }

    public void Pause()
    {
        showUI = 2;
    }

    public void MainMenu()
    {
        Save();
        showUI = 1;
    }

    public void Quit()
    {
        Application.Quit();
    }

    void Save()
    {
        // Get Player Prefs
        PlayerPrefs.SetInt("wave", currentWave);
        PlayerPrefs.SetInt("health", currentHealth);
        PlayerPrefs.SetInt("ammo", currentAmmo);
    }

    void Load()
    {
        // Get Player Prefs
        PlayerPrefs.GetInt("wave", currentWave);
        PlayerPrefs.GetInt("health", currentHealth);
        PlayerPrefs.GetInt("ammo", currentAmmo);
    }
}
