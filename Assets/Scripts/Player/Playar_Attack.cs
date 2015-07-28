using UnityEngine;
using System.Collections;

public class Playar_Attack : MonoBehaviour {

    Gun gun;
    MachineGun machineGun;
    RocketLauncher rocketLauncher;
    Shotgun shotgun;

    int gunIndex = 0;
    int maxGuns = 3;

    public int SelectedGun
    {
        get
        {
            return gunIndex;
        }
    }

	// Use this for initialization
	void Start () {
        machineGun = GetComponent<MachineGun>();
        rocketLauncher = GetComponent<RocketLauncher>();
        gun = GetComponent<Gun>();
        shotgun = GetComponent<Shotgun>();
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetAxis("Mouse ScrollWheel") > 0 || Input.GetButtonDown("Weapon Up"))
        {
            gunIndex += 1;
            if (gunIndex > maxGuns)
            {
                gunIndex = 0;
            }
        }
        if (Input.GetAxis("Mouse ScrollWheel") < 0 || Input.GetButtonDown("Weapon Down"))
        {
            gunIndex -= 1;
            if (gunIndex < 0)
            {
                gunIndex = maxGuns;
            }
        }
	}

    void FixedUpdate()
    {
        if (Input.GetButton("Fire1"))
        {
            switch (gunIndex)
            {
                case 0:
                    gun.Fire();
                    break;
                case 1:
                    machineGun.Fire();
                    break;
                case 2:
                    rocketLauncher.Fire();
                    break;
                case 3:
                    shotgun.Fire();
                    break;
                default:
                    break;
            }
        }
    }
}
