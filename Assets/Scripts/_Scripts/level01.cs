using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class level01 : MonoBehaviour {

    public Text timerText;
    public GameObject Player;
    public Text textScore;

    float time = 0;
    public bool stopTime = true;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
        GameObject[] gos = GameObject.FindGameObjectsWithTag("Enemy");
        if (gos.Length == 0)
        {
            stopTime = true;
            Win();
            GetComponent<Functions>().Win();
        }

        if (!stopTime)
        {
            time += Time.deltaTime;
        }

        timerText.text = Mathf.Floor(time / 60).ToString("00") + ":" + (time % 60).ToString("00");
	}

    void OnTriggerEnter()
    {
        stopTime = false;
        Destroy(collider);
    }

    public int GetScore()
    {
        int s = 0;
        float ts = 6000 / time;
        float prec = ((float)GlobalVariables.shotsHit / (float)GlobalVariables.shotsFired) * 100f;
        float preccoef = prec * 0.2236f;
        float ps = preccoef * preccoef;
        float hs = Player.GetComponent<Destructible>().Health / 2f;

        s = (int)ts + (int)ps + (int)hs;
        return s;
    }

    void Win()
    {
        textScore.text = "Points: " + GetScore().ToString();
    }
}
