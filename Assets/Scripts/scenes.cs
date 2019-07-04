﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class scenes : MonoBehaviour
{
    AudioSource tapSound;
    public AudioClip clickSound;
    public float volume;

    public GameObject MainMenu;
    public GameObject SettingsMenu;

    public GameObject breakableCube;

    void Start()
    {
        tapSound = GetComponent<AudioSource>();
    }
    public void LoadLevel1()
    {

        tapSound.PlayOneShot(clickSound, volume);
        
        SceneManager.LoadScene("Level1",LoadSceneMode.Single);
        
    }

    public void LoadLeve2()
    {

        tapSound.PlayOneShot(clickSound, volume);

        SceneManager.LoadScene("Level2", LoadSceneMode.Single);

    }



    public void LoadMainMenu()
    {
        tapSound.PlayOneShot(clickSound, volume);
        SceneManager.LoadScene("Menu", LoadSceneMode.Single);
    }

    public void CloseGame()
    {
        tapSound.PlayOneShot(clickSound, volume);
        Application.Quit();
    }

    public void BacktoMenu()
    {
        tapSound.PlayOneShot(clickSound, volume);
        MainMenu.SetActive(true);
        SettingsMenu.SetActive(false);
    }

    public void GoToSettings()
    {
        tapSound.PlayOneShot(clickSound, volume);
        MainMenu.SetActive(false);
        SettingsMenu.SetActive(true);
    }

     public void ToggleMute()
    {
        AudioListener.pause = !AudioListener.pause;
    }

}
