using UnityEngine;
using System.Collections;

public class MachineGun : MonoBehaviour {

    public float Cooldown = 0.2f;
    public float Range = 200.0f;
    public GameObject hitEffect;
    public float Demage = 2.0f;
    public AudioClip audioClip;

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
            Ray ray = new Ray(Camera.main.transform.position + Camera.main.transform.forward * 0.4f, Camera.main.transform.forward);

            RaycastHit hitInfo;

            if (Physics.Raycast(ray, out hitInfo, Range))
            {
                Instantiate(hitEffect, hitInfo.point, Quaternion.LookRotation(Camera.main.transform.position - hitInfo.normal));
                Destructible d = hitInfo.collider.gameObject.GetComponent<Destructible>();
                Rigidbody r = hitInfo.collider.gameObject.GetComponent<Rigidbody>();
                if (d != null)
                {
                    if (d.gameObject.tag == "Enemy")
                    {
                        GlobalVariables.shotsHit++;
                    }
                    d.Health -= Demage;
                }
                if (r != null)
                {
                    r.AddForce(hitInfo.normal * (-Demage), ForceMode.Impulse);
                }
            }
            AudioSource.PlayClipAtPoint(audioClip, Camera.main.transform.position);
            cooldownRem = Cooldown;
            GetComponent<FirstPersonController>().RoteateY(3f);
        }
    }
}
