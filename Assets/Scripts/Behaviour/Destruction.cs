using UnityEngine;
using System.Collections;

public class Destruction : MonoBehaviour {
    public GameObject debris;


    Destructible d;

	// Use this for initialization
	void Start () {
        d = GetComponent<Destructible>();
	}
	
	// Update is called once per frame
	void Update () {
        if (d.Health <= 0)
        {
            Instantiate(debris, transform.position, transform.rotation);
            Destroy(gameObject);
        }
	}   
}
