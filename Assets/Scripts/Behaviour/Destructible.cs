using UnityEngine;
using System.Collections;

public class Destructible : MonoBehaviour {

    public float health = 10.0f;
    public float Health
    {
        get
        {
            return _health;
        }
        set
        {
            _health = value;
        }
    }

    float _health;
	// Use this for initialization
	void Start () {
        _health = health;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
