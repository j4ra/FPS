using UnityEngine;
using System.Collections;

public class Shotgun : MonoBehaviour {

    public float Cooldown = 1f;
    public float Range = 50.0f;
    public GameObject hitEffect;
    public float Demage = 1.0f;
    public AudioClip audioClip;
    public float spreadAngleD = 7f;

    float cooldownRem = 0f;
    float deviation;
    // Use this for initialization
    void Start()
    {
        deviation = Mathf.Tan(Mathf.Deg2Rad * spreadAngleD);
    }

    // Update is called once per frame
    void Update()
    {
        if (cooldownRem > 0)
        {
            cooldownRem -= Time.deltaTime;
        }
    }

    public void Fire()
    {
        if (cooldownRem <= 0)
        {
            for (int i = 0; i < 16; i++)
            {
                GlobalVariables.shotsFired++;
                Vector3 forward = Camera.main.transform.forward;
                Vector3 rndVec = new Vector3(Random.Range(-deviation, deviation), Random.Range(-deviation, deviation), Random.Range(-deviation, deviation));
                Ray ray = new Ray(Camera.main.transform.position + Camera.main.transform.forward * 0.4f, forward + rndVec);
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
                        d.Health -= Demage / 2f;
                    }

                    if (r != null)
                    {
                        r.AddForce(hitInfo.normal * (-Demage), ForceMode.Impulse);
                    }
                }
            }

            AudioSource.PlayClipAtPoint(audioClip, Camera.main.transform.position);
            cooldownRem = Cooldown;
            GetComponent<FirstPersonController>().RoteateY(5f);
        }
    }
}
