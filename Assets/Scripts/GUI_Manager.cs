using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;



public class GUI_Manager : MonoBehaviour
{
    public int showUI;
    public string wave; //, health, ammo
    public GameObject mainMenu, options, gameUI;
    public int currentWave;
    public bool mute;
    public Toggle muteToggle;
    public AudioSource music, sfx;
    public GameObject player;
    public Image healthBar;
    public int currentHealth, maxHealth;


    void Awake()
    {
        showUI = 1;
        mute = false;
        maxHealth = 100;
        currentHealth = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        SwitchUI();
        HealthBar();
    }

    #region UISwitch
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
    #endregion

    #region MainMenu
    public void Play()
    {
        if (showUI == 1)
        {
            Load();
            showUI = 3;
        }
        else
            showUI = 3;
    }

    public void NewGame()
    {
        PlayerPrefs.SetInt(wave, 0);
        //PlayerPrefs.SetInt(health, 100);
        //PlayerPrefs.SetInt(ammo, 100);
        showUI = 3;
    }

    public void Quit()
    {
        Application.Quit();
    }
    #endregion

    #region PauseMenu
    public void Pause()
    {
        showUI = 2;
    }

    public void MainMenu()
    {
        Save();
        showUI = 1;
    }

    public void Mute()
    {
        ToggleMute();
    }

    public bool ToggleMute()
    {
        if (mute) // if full screen is on
        {
            muteToggle.isOn = true;
            mute = true;
            music.mute = true;
            sfx.mute = true;
            return false; // set it to false
        }
        else
        {
            muteToggle.isOn = false;
            mute = false;
            music.mute = false;
            sfx.mute = false;
            return true; // set it to true
        }
    }
    #endregion

    #region GameUI
    void HealthBar()
    {
        healthBar.fillAmount = (float)currentHealth / (float)maxHealth;
        if (currentHealth > maxHealth)
        {
            currentHealth = maxHealth;
        }
        if (currentHealth < 0)
        {
            currentHealth = 0;
        }
    }
    #endregion

    #region SaveandLoad
    void Save()
    {
        // Get Player Prefs
        PlayerPrefs.SetInt(wave, currentWave);
        //PlayerPrefs.SetInt(health, currentHealth);
        //PlayerPrefs.SetInt(ammo, currentAmmo);
    }

    void Load()
    {
        // Get Player Prefs
        PlayerPrefs.GetInt(wave, currentWave);
        //PlayerPrefs.GetInt(health, currentHealth);
        // PlayerPrefs.GetInt(ammo, currentAmmo);
    }
    #endregion
}
