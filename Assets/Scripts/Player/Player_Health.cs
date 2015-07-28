using UnityEngine;
using System.Collections;

public class Player_Health : MonoBehaviour {
    Functions fnc;
    public GameObject _Scripts;

    Playar_Attack pa;
    FirstPersonController fpc;
    Destructible d;
    CameraZoom cz;
	// Use this for initialization
	void Start () {
        fnc = _Scripts.GetComponent<Functions>();
        pa = GetComponent<Playar_Attack>();
        fpc = GetComponent<FirstPersonController>();
        d = GetComponent<Destructible>();
        cz = Camera.main.GetComponent<CameraZoom>();
	}
	
	// Update is called once per frame
	void Update () {
        if (d.Health <= 0)
        {
            pa.enabled = false;
            fpc.enabled = false;
            cz.enabled = false;
            fnc.Lose();
        }
	}
}
