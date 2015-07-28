using UnityEngine;
using System.Collections;

public class BlinkingLight : MonoBehaviour {
    public float blinkTime = 0.3f;
    public bool random = false;

    float timer = 0;
    float time;
	// Use this for initialization
	void Start () {
        if (!random)
        {
            InvokeRepeating("Blink", 0.01f, blinkTime);
        }
        else
        {
            time = Random.Range(0f, blinkTime);
        }
	}

    void Update()
    {
        if (random)
        {
            timer += Time.deltaTime;
            if (timer >= time)
            {
                Blink();
                timer = 0f;
                time = Random.Range(0f, blinkTime);
            }
        }
    }

    void Blink()
    {
        for (int i = 0; i < transform.childCount; i++)
        {
            GameObject go = transform.GetChild(i).gameObject;
            go.SetActive(!go.activeSelf);
        }
    }
}
