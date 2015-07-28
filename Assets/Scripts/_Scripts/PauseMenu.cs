using UnityEngine;
using System.Collections;

public class PauseMenu : MonoBehaviour {
    public Canvas hud;
    public Canvas pauseMenu;
    public GameObject Player;

    FirstPersonController fpc;
    Playar_Attack pa;
    bool paused = false;
	// Use this for initialization
	void Start () {
        fpc = Player.GetComponent<FirstPersonController>();
        pa = Player.GetComponent<Playar_Attack>();
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetButtonDown("Pause") && !GlobalVariables.Settings_displayed)
        {
            TogglePause();
        }
	}

    public void TogglePause()
    {
        if (paused)
        {
            Time.timeScale = 1f;
            pauseMenu.enabled = false;
            hud.enabled = true;
            Screen.showCursor = false;
            Screen.lockCursor = true;
            fpc.enabled = true;
            pa.enabled = true;
        }
        else
        {
            fpc.enabled = false;
            pauseMenu.enabled = true;
            hud.enabled = false;
            Screen.showCursor = true;
            Screen.lockCursor = false;
            Time.timeScale = 0f;
            fpc.enabled = false;
            pa.enabled = false;
        }
        paused = !paused;
    }
}
