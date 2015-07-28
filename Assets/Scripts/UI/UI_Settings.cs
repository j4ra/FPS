using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class UI_Settings : MonoBehaviour {
    public Slider musicVol;
    public Text qualityText;
    public Text aaText;
    public Text resoText;
    public Toggle fsToggle;
    public Canvas menu;

	// Use this for initialization
	void Start () {
        musicVol.value = GlobalVariables.MusicVolume;
        updateResoText();
        qualityText.text = QualitySettings.names[QualitySettings.GetQualityLevel()];
        updateAAtext();
        Screen.SetResolution(GlobalVariables.ScreenWidth, GlobalVariables.ScreenHeight, GlobalVariables.Fullscreen);
        fsToggle.isOn = GlobalVariables.Fullscreen;
	}

    public void Back()
    {
        Canvas c = GetComponent<Canvas>();
        c.enabled = false;
        menu.enabled = true;
        GlobalVariables.Settings_displayed = false;
    }

    public void ChangeVolume()
    {
        GlobalVariables.MusicVolume = musicVol.value;
    }

    public void Save()
    {
        PlayerPrefs.SetFloat("music_volume", GlobalVariables.MusicVolume);
        PlayerPrefs.SetInt("quality_level", GlobalVariables.QualityLevel);
        PlayerPrefs.SetInt("aa_level", GlobalVariables.AALevel);
        PlayerPrefs.SetInt("screen_height", GlobalVariables.ScreenHeight);
        PlayerPrefs.SetInt("screen_width", GlobalVariables.ScreenWidth);
        PlayerPrefs.SetString("fullscreen", GlobalVariables.Fullscreen.ToString());
    }

    public void UpQuality()
    {
        QualitySettings.IncreaseLevel(true);
        GlobalVariables.QualityLevel = QualitySettings.GetQualityLevel();
        qualityText.text = QualitySettings.names[QualitySettings.GetQualityLevel()];
        updateAAtext();
    }
    public void DownQuality()
    {
        QualitySettings.DecreaseLevel(true);
        GlobalVariables.QualityLevel = QualitySettings.GetQualityLevel();
        qualityText.text = QualitySettings.names[QualitySettings.GetQualityLevel()];
        updateAAtext();
    }

    public void UpAA()
    {
        int curAA = QualitySettings.antiAliasing;
        switch (curAA)
        {
            case 0:
                curAA = 2;
                aaText.text = "2";
                break;
            case 2:
                aaText.text = "4";
                curAA = 4;
                break;
            case 4:
                aaText.text = "8";
                curAA = 8;
                break;
            case 8:
                aaText.text = "8";
                curAA = 8;
                break;
            default:
                aaText.text = "none";
                curAA = 0;
                break;
        }
        QualitySettings.antiAliasing = curAA;
        GlobalVariables.AALevel = curAA;
    }

    public void DownAA()
    {
        int curAA = QualitySettings.antiAliasing;
        switch (curAA)
        {
            case 0:
                curAA = 0;
                aaText.text = "none";
                break;
            case 2:
                aaText.text = "none";
                curAA = 0;
                break;
            case 4:
                aaText.text = "2";
                curAA = 2;
                break;
            case 8:
                aaText.text = "4";
                curAA = 4;
                break;
            default:
                aaText.text = "none";
                curAA = 0;
                break;
        }
        QualitySettings.antiAliasing = curAA;
        GlobalVariables.AALevel = curAA;
    }

    void updateAAtext()
    {
        int curAA = QualitySettings.antiAliasing;
        switch (curAA)
        {
            case 0:
                aaText.text = "none";
                break;
            case 2:
                aaText.text = "2";
                break;
            case 4:
                aaText.text = "4";
                break;
            case 8:
                aaText.text = "8";
                break;
            default:
                aaText.text = "none";
                break;
        }
    }

    void updateResoText()
    {
        resoText.text = GlobalVariables.ScreenWidth+ "x" + GlobalVariables.ScreenHeight;
    }

    public void UpReso()
    {
        Resolution[] resos = Screen.GetResolution;
        if (resos.Length == 0)
        {
            resos = new Resolution[1];
            resos[0] = Screen.currentResolution;
        }
        int i = 0;
        for (; i < resos.Length; i++)
        {
            if (resos[i].Equals(Screen.currentResolution))
            {
                break;
            }
        }
        i++;
        if (i >= resos.Length)
        {
            i = resos.Length - 1;
        }
        Screen.SetResolution(resos[i].width, resos[i].height, GlobalVariables.Fullscreen);
        GlobalVariables.ScreenHeight = resos[i].height;
        GlobalVariables.ScreenWidth = resos[i].width;
        updateResoText();
    }

    public void DownReso()
    {
        Resolution[] resos = Screen.GetResolution;
        if (resos.Length == 0)
        {
            resos = new Resolution[1];
            resos[0] = Screen.currentResolution;
        }
        int i = 0;
        for (; i < resos.Length; i++)
        {
            if (resos[i].Equals(Screen.currentResolution))
            {
                break;
            }
        }
        i--;
        if (i < 0)
        {
            i = 0;
        }
        Screen.SetResolution(resos[i].width, resos[i].height, GlobalVariables.Fullscreen);
        GlobalVariables.ScreenHeight = resos[i].height;
        GlobalVariables.ScreenWidth = resos[i].width;
        updateResoText();
    }

    public void ChangeFullScreen()
    {
        GlobalVariables.Fullscreen = fsToggle.isOn;
        Screen.SetResolution(GlobalVariables.ScreenWidth, GlobalVariables.ScreenHeight, GlobalVariables.Fullscreen);
    }
}
