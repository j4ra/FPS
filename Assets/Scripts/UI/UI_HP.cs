using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class UI_HP : MonoBehaviour {
    public GameObject Player;
    Destructible d;
    Text text;
	// Use this for initialization
	void Start () {
        d = Player.GetComponent<Destructible>();
        text = GetComponent<Text>();
	}
	
	// Update is called once per frame
	void Update () {
        text.text = "HP: " + Mathf.RoundToInt(d.Health).ToString();
    }
}
