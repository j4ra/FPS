using UnityEngine;
using System.Collections;

public class Bullet_ThermalDetonator : MonoBehaviour {

    float lifespan = 3.0f;

    public float demage = 5f;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        lifespan -= Time.deltaTime;

        if (lifespan < 0)
        {
            Explode();
        }
	}

    private void Explode()
    {
        Destroy(gameObject);
    }

    void OnCollisionEnter(Collision collision) {
        if (collision.gameObject.tag == "Enemy")
        {
            Destructible d = collision.gameObject.GetComponent<Destructible>();
            if (d != null)
            {
                d.Health -= demage;
            }
            Destroy(gameObject);
        }
    }
}
