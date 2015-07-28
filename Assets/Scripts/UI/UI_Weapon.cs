using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class UI_Weapon : MonoBehaviour {

    public GameObject Player;
    Playar_Attack pa;

    Image img;
    public Sprite gun;
    public Sprite machinegun;
    public Sprite rocket;
    public Sprite shotgun;
	// Use this for initialization
	void Start () {
        pa = Player.GetComponent<Playar_Attack>();
        img = GetComponent<Image>();
	}
	
	// Update is called once per frame
	void Update () {
	    switch(pa.SelectedGun)
        {
            case 0:
                img.sprite = gun;
                break;
            case 1:
                img.sprite = machinegun;
                break;
            case 2:
                img.sprite = rocket;
                break;
            case 3:
                img.sprite = shotgun;
                break;
        }
	}
}
