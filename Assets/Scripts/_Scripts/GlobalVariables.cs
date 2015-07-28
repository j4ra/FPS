using UnityEngine;
using System.Collections;

public class GlobalVariables : MonoBehaviour {

    public static float MusicVolume;
    public static int QualityLevel;
    public static int AALevel;
    public static int ScreenHeight;
    public static int ScreenWidth;
    public static bool Fullscreen;

    public static bool Settings_displayed = false;
    public static int shotsFired = 0;
    public static int shotsHit = 0;

	// Use this for initialization
	void Start () {
        GlobalVariables.MusicVolume = PlayerPrefs.GetFloat("music_volume", 0.2f);
        GlobalVariables.QualityLevel = PlayerPrefs.GetInt("quality_level", 3);
        GlobalVariables.AALevel = PlayerPrefs.GetInt("aa_level", 0);
        GlobalVariables.ScreenHeight = PlayerPrefs.GetInt("screen_height", 768);
        GlobalVariables.ScreenWidth = PlayerPrefs.GetInt("screen_width", 1024);
        GlobalVariables.Fullscreen = bool.Parse( PlayerPrefs.GetString("fullscreen", "false"));
	}
	
	// Update is called once per frame
	void Update () {
	    
	}
}
