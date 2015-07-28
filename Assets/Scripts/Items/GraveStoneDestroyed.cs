using UnityEngine;
using System.Collections;

public class GraveStoneDestroyed : MonoBehaviour {
    Destructible d;
	// Use this for initialization
	void Start () {
        d = GetComponent<Destructible>();
	}
	
	// Update is called once per frame
	void Update () {
        if (d.Health <= 0)
        {
            rigidbody.isKinematic = false;
        }
	}

    void OnCollisionEnter(Collision c)
    {
        if (c.relativeVelocity.magnitude > 2f)
        {
            rigidbody.isKinematic = false;
        }
    }
}
