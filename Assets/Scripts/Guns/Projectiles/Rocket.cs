using UnityEngine;
using System.Collections;

public class Rocket : MonoBehaviour {

    public float speed = 0f;
    public float demage = 200f;
    public float radius = 5f;
    public float timeOut = 10f;

    public GameObject explosionEffect;
    public GameObject traceEffect;

    public float traceEffectDistance = 0.1f;


    float traceEffectTime = 0f;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        Vector3 move = transform.forward * speed * Time.deltaTime;
        transform.Translate(move, Space.World);

        if (traceEffectTime <= 0)
        {
            Instantiate(traceEffect, transform.position, transform.rotation);
            traceEffectTime = traceEffectDistance;
        }
        traceEffectTime -= Time.deltaTime;
        timeOut -= Time.deltaTime;

        if (timeOut <= 0)
        {
            Destroy(gameObject);
        }
	}

    void OnTriggerEnter()
    {
        Explode();
    }

    private void Explode()
    {
        Instantiate(explosionEffect, transform.position, Quaternion.identity);

        Collider[] colliders = Physics.OverlapSphere(transform.position, radius);
        bool statCounted = false;
        foreach (Collider c in colliders)
        {
            float dist = Vector3.Distance(transform.position, c.transform.position);
            Destructible d = c.gameObject.GetComponent<Destructible>();
            Rigidbody r = c.gameObject.GetComponent<Rigidbody>();
            if (d != null)
            {
                d.Health -= (demage / (radius * radius)) * (dist - radius) * (dist - radius);
                if (!statCounted)
                {
                    statCounted = true;
                    if (c.gameObject.tag == "Enemy")
                    {
                        GlobalVariables.shotsHit++;
                    }
                }
            }

            if (r != null)
            {
                r.AddExplosionForce(((demage / (radius * radius)) * (dist - radius) * (dist - radius)) * 100f, transform.position, radius);
            }
        }
        
        Destroy(gameObject);
    }
}
