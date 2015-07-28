using UnityEngine;
using System.Collections;

[RequireComponent (typeof(CharacterController))]
public class FirstPersonController : MonoBehaviour {

    public float movementSpeed = 10.0f;
    public float rotationSpeed = 2.0f;
    public float upDownRange = 60.0f;
    public float jumpSpeed = 20.0f;
    public float sprintConstant = 2.0f;
    public float crouchConstant = 0.75f;
    public AudioSource audioSource;
    public AudioClip audioSlow;
    public AudioClip audioMedium;
    public AudioClip audioFast;

    float pitch = 0;
    float originalPitch;
    float verticalSpeed = 0;
    float verticalDelta = 0;
    float prevVerticalPosition;
    bool recoiled = false;
    float mouseYprev = 0f;
    CharacterController cc;
	// Use this for initialization
	void Start () {
        Screen.lockCursor = true;
        cc = GetComponent<CharacterController>();
        audioSource.clip = audioMedium;
        audioSource.volume = 0.9f;
        prevVerticalPosition = transform.position.y;
        originalPitch = pitch;
	}
	
	// Update is called once per frame
	void Update () {
        verticalDelta = prevVerticalPosition - transform.position.y;
        prevVerticalPosition = transform.position.y;


        if (verticalDelta == 0)
        {
            verticalSpeed = 0;
        }

        //Rotation
        if (originalPitch != pitch && recoiled)
        {
            pitch -= (pitch - originalPitch) / 2;
        }
        if (!recoiled)
        {
            originalPitch = pitch;
        }
        if ((Mathf.Abs(pitch - originalPitch) < 0.01f || Mathf.Abs(Input.GetAxis("Mouse Y") - mouseYprev) > 0.01f) && recoiled)
        {
            recoiled = false;
            originalPitch = pitch;
        }

        float yaw = Input.GetAxis("Mouse X") * rotationSpeed;

        transform.Rotate(0, yaw, 0);


        pitch -= Input.GetAxis("Mouse Y") * rotationSpeed;
        mouseYprev = Input.GetAxis("Mouse Y");

        pitch = Mathf.Clamp(pitch, -upDownRange, upDownRange);

        Camera.main.transform.localRotation = Quaternion.Euler(pitch, 0, 0);

        //Movement
        verticalSpeed += Physics.gravity.y * Time.deltaTime;

        float forwardSpeed = Input.GetAxis("Vertical") * movementSpeed;
        float sideSpeed = Input.GetAxis("Horizontal") * movementSpeed;

        if ((Mathf.Abs(forwardSpeed) > 2.5f || Mathf.Abs(sideSpeed) > 2.5f) && cc.isGrounded)
        {
            if (!audioSource.isPlaying)
            {
                audioSource.Play();
                audioSource.mute = false;
            }
        }
        else
        {
            audioSource.Stop();
            audioSource.mute = true;
        }

        if (cc.isGrounded && Input.GetButtonDown("Jump") && !Input.GetButton("Crouch"))
        {
            verticalSpeed = jumpSpeed;
        }

        if (Input.GetButton("Sprint") && cc.isGrounded)
        {
            forwardSpeed *= sprintConstant;
            audioSource.clip = audioFast;
            audioSource.volume = 1.0f;
        }
        else if (Input.GetButtonUp("Sprint"))
        {
            audioSource.clip = audioMedium;
            audioSource.volume = 0.9f;
        }

        if (Input.GetButton("Crouch") && !Input.GetButton("Sprint") && cc.isGrounded)
        {
            Vector3 camPos = new Vector3(0, 1, 0);
            Camera.main.transform.localPosition = camPos;
            cc.height = 1.25f;
            cc.center = new Vector3(0, 0.635f, 0);
            forwardSpeed *= crouchConstant;
            sideSpeed *= crouchConstant;
            audioSource.clip = audioSlow;
            audioSource.volume = 0.4f;
        }
        else if (Input.GetButtonUp("Crouch") && !Input.GetButton("Sprint") && cc.isGrounded)
        {
            Vector3 camPos = new Vector3(0, 1.75f, 0);
            Camera.main.transform.localPosition = camPos;
            cc.center = new Vector3(0, 1.01f, 0);
            cc.height = 2.0f;
            audioSource.clip = audioMedium;
            audioSource.volume = 0.9f;
        }

        Vector3 speed = new Vector3(sideSpeed, verticalSpeed, forwardSpeed);
        speed = transform.rotation * speed;

        cc.Move(speed * Time.deltaTime);
	}

    public void RoteateY(float amt)
    {
        originalPitch = pitch;
        pitch -= amt;
        recoiled = true;
    }
}
