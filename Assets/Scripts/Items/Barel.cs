using UnityEngine;
using System.Collections;

public class Barel : MonoBehaviour {
    Destructible d;

    public GameObject ExplosionEffect;
    public GameObject FlameEffect;
    public float radius = 10f;
    public float demage = 75f;

    public float burningTime = 1.0f;

    bool burning = false;
	// Use this for initialization
	void Start () {
        d = GetComponent<Destructible>();
	}
	
	// Update is called once per frame
	void Update () {
        if (d.Health <= 0 && !burning)
        {
            burning = true;
            GameObject go = (GameObject)Instantiate(FlameEffect, transform.position, Quaternion.identity);
            go.transform.SetParent(transform);
        }
        if (burning)
        {
            burningTime -= Time.deltaTime;
        }
        if (burningTime <= 0)
        {
            Explode();
        }
	}

    void Explode()
    {
        Instantiate(ExplosionEffect, transform.position, Quaternion.identity);

        Collider[] colliders = Physics.OverlapSphere(transform.position, radius);

        foreach (Collider c in colliders)
        {
            Destructible dc = c.gameObject.GetComponent<Destructible>();
            Rigidbody r = c.gameObject.GetComponent<Rigidbody>();
            float dist = Vector3.Distance(transform.position, c.transform.position);
            if (dc != null)
            {   
                dc.Health -= (demage / (radius * radius)) * (dist - radius) * (dist - radius);
            }
            if (r != null)
            {
                r.AddExplosionForce(((demage / (radius * radius)) * (dist - radius) * (dist - radius)) * 100f, transform.position, radius);
            }
        }

        Destroy(gameObject);
    }
}
