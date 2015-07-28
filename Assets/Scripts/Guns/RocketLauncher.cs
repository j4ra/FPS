using UnityEngine;
using System.Collections;

public class RocketLauncher : MonoBehaviour {

    public float Cooldown = 2f;
    public GameObject rocket;

    float cooldownRem = 0f;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        if (cooldownRem > 0)
        {
            cooldownRem -= Time.deltaTime;
        }
	}

    public void Fire()
    {
        if (cooldownRem <= 0)
        {
            GlobalVariables.shotsFired++;
            Instantiate(rocket, Camera.main.transform.position + Camera.main.transform.forward * 1.2f, Camera.main.transform.rotation);
            cooldownRem = Cooldown;
            GetComponent<FirstPersonController>().RoteateY(10);
        }
    }
}
