using UnityEngine;
using System.Collections;

public class Functions : MonoBehaviour {

    public Canvas lose;
    public Canvas hud;
    public Canvas win;
    public GameObject Player;
    public Canvas debugInfo;

    public Canvas settings;
    public Canvas menu;

    void Start()
    {
        Time.timeScale = 1f;
        QualitySettings.SetQualityLevel(GlobalVariables.QualityLevel, true);
        QualitySettings.antiAliasing = GlobalVariables.AALevel;
        Screen.SetResolution(GlobalVariables.ScreenWidth, GlobalVariables.ScreenHeight, GlobalVariables.Fullscreen);
        
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F11))
        {
            GlobalVariables.Fullscreen = !GlobalVariables.Fullscreen;
            Screen.SetResolution(GlobalVariables.ScreenWidth, GlobalVariables.ScreenHeight, GlobalVariables.Fullscreen);
        }
        if (Input.GetKeyDown(KeyCode.F10))
        {
            GlobalVariables.ScreenHeight = Screen.GetResolution[Screen.GetResolution.Length - 1].height;
            GlobalVariables.ScreenWidth = Screen.GetResolution[Screen.GetResolution.Length - 1].width;
            Screen.SetResolution(GlobalVariables.ScreenWidth, GlobalVariables.ScreenHeight, GlobalVariables.Fullscreen);
        }
        if (Input.GetKey(KeyCode.LeftAlt) && Input.GetKeyDown(KeyCode.F5))
        {
            PlayerPrefs.SetFloat("music_volume", GlobalVariables.MusicVolume);
            PlayerPrefs.SetInt("quality_level", GlobalVariables.QualityLevel);
            PlayerPrefs.SetInt("aa_level", GlobalVariables.AALevel);
            PlayerPrefs.SetInt("screen_height", GlobalVariables.ScreenHeight);
            PlayerPrefs.SetInt("screen_width", GlobalVariables.ScreenWidth);
            PlayerPrefs.SetString("fullscreen", GlobalVariables.Fullscreen.ToString());
            PlayerPrefs.Save();
        }
        if (Input.GetKeyDown(KeyCode.F12))
        {
            debugInfo.enabled = !debugInfo.enabled;
        }
    }

    public void Exit()
    {
        Application.Quit();
    }

    public void Lose()
    {
        Time.timeScale = 0.1f;
        lose.enabled = true;
        GetComponent<PauseMenu>().enabled = false;
        Screen.lockCursor = false;
        Screen.showCursor = true;
        Player.GetComponent<FirstPersonController>().enabled = false;
        Player.GetComponent<Playar_Attack>().enabled = false;
        Camera.main.GetComponent<CameraZoom>().enabled = false;
        hud.enabled = false;
    }

    public void Win()
    {
        Time.timeScale = 0.1f;
        win.enabled = true;
        GetComponent<PauseMenu>().enabled = false;
        Player.GetComponent<FirstPersonController>().enabled = false;
        Player.GetComponent<Playar_Attack>().enabled = false;
        Camera.main.GetComponent<CameraZoom>().enabled = false;
        Screen.lockCursor = false;
        Screen.showCursor = true;
        hud.enabled = false;
    }

    public void SettingsCanvas()
    {
        menu.enabled = false;
        settings.enabled = true;
        GlobalVariables.Settings_displayed = true;
    }

    public void MenuCanvas()
    {
        menu.enabled = true;
        settings.enabled = false;
        GlobalVariables.Settings_displayed = false;
    }

    public void LoadMainMenu()
    {
        Application.LoadLevel("main_menu");
    }

    public void LoadLevel(int l)
    {
        Application.LoadLevel(l);
    }

}
