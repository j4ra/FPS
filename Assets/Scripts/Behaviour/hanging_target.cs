using UnityEngine;
using System.Collections;

public class hanging_target : MonoBehaviour {

    public float activationRadius = 10f;

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
        Collider[] colliders = Physics.OverlapSphere(transform.position, activationRadius);
        foreach (Collider c in colliders)
        {
            if (c.gameObject.tag == "Player")
            {
                hingeJoint.useLimits = false;
            }
        }
	}
}
