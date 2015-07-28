using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour {


    public float TimeOut = 3.0f;
    public GameObject ExpolsionEffect;
    public GameObject FireEffect;
    public bool destroyParent = false;

    Destructible destructible;

    float _timeOut;

	// Use this for initialization
	void Start () {
        _timeOut = TimeOut;
        destructible = GetComponent<Destructible>();
	}
	
	// Update is called once per frame
	void Update () {
        if (transform.tag == "Dead")
        {
            _timeOut -= Time.deltaTime;
            if (_timeOut < 0)
            {
                Destroy(gameObject);
                if (destroyParent)
                {
                    Destroy(transform.parent.gameObject);
                }
                Instantiate(ExpolsionEffect, transform.position, transform.rotation);
            }
        }

        if (destructible.Health <= 0 && transform.tag != "Dead")
        {
            transform.tag = "Dead";
            GameObject faya = (GameObject)Instantiate(FireEffect, transform.position, Quaternion.identity);
            faya.transform.parent = gameObject.transform;
        }
	}
}
