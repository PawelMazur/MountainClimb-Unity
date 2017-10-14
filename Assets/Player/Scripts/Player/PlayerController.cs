using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour {

	// Use this for initialization

    float speed = 10;
    Rigidbody2D rigidbody2D;
    float maxSpeed = 100f;

    public WheelJoint2D wheelBack;
    public WheelJoint2D wheelFront;

    public float speedBack;
    public float speedFront;

    public float motorTorqueBack;
    public float motorTorqueFront;

    JointMotor2D motorBack;
    JointMotor2D motorFront;

    JointSuspension2D suspensionLeft;
    JointSuspension2D suspensionRight;

    public bool tractionBack = true;
    public bool tractionFront = true;

    //public Transform checkGround;
    //public LayerMask whatIsGround;
    //public bool ground;

    private GameController gameController;

    AudioSource audioSurce;
    public AudioClip audioClipEngine;
    public AudioClip audioClipSpeed;
    public AudioClip audioClipRetreat;
    public AudioClip audioClipSkid;
    public AudioClip audioClipStartEngine;

    public float waitForNextClipSpeed = 0.5f;
    public float nextClipSpeed = 0f;

    public float waitForNextClipRetreat = 0.5f;
    public float nextClipRetreat = 0f;

    public float waitForNextClipSkid = 2f;
    public float nextClipSkid = 0f;

    public bool startEngine = false;

    public SpeedButton speedButton;
    public RetreatButton retreatButton;

	void Start () {

        
        GameObject gameObject = GameObject.FindGameObjectWithTag("GameController");
        if (gameObject != null)
        {
            gameController = gameObject.GetComponent<GameController>();
        } if (gameObject == null)
        {
            Debug.Log("Dont find script 'GameController' ");
        }
       

        PlayerCanvas.canvas.SetGameStatus("");
        PlayerCanvas.canvas.SetLogText("");

        rigidbody2D = GetComponent<Rigidbody2D>();
        audioSurce = GetComponent<AudioSource>();
        Invoke("AudioStartEngine", 2);
        Invoke("StartEngineM", 2);
    }

    void Update()
    {

    }

    public void StartEngineM()
    {
        startEngine = true;
    }
	
	// Update is called once per frame
	void FixedUpdate () {

        if (startEngine)
        {
            playerSpeed();
        }
       
	}

    void playerSpeed()
    {
        float horizontal = Input.GetAxis("Horizontal");

        //Debug.Log("Horizontal : " + horizontal);
        
        if (horizontal > 0)
        {
            if (tractionBack)
            {
                motorBack.motorSpeed = horizontal * speedBack;
                //motorBack.motorSpeed = speedButton.Horizontal() * speedBack;
                motorBack.maxMotorTorque = motorTorqueBack;
                //print(" motorSpeed : " + speedButton.getValueTorque());
            }

            if (tractionFront)
            {
                motorFront.motorSpeed = horizontal * speedFront;
                //motorFront.motorSpeed = speedButton.Horizontal() * speedFront;
                motorFront.maxMotorTorque = motorTorqueFront;
            }
        }

        else
        {
            if (tractionBack)
            {
                motorBack.motorSpeed = 0 * speedBack;
                motorBack.maxMotorTorque = motorTorqueBack;
            }

            if (tractionFront)
            {
                motorFront.motorSpeed = 0 * speedFront;
                motorFront.maxMotorTorque = motorTorqueFront;
            }
        }

        #if UNITY_STANDALONE || UNITY_WEBPLAYER
        /*
        if (horizontal > 0)
        {
            if (tractionBack)
            {
                motorBack.motorSpeed = horizontal * speedBack;
                //motorBack.motorSpeed = speedButton.Horizontal() * speedBack;
                motorBack.maxMotorTorque = motorTorqueBack;
                //print(" motorSpeed : " + speedButton.getValueTorque());
            }

            if (tractionFront)
            {
                motorFront.motorSpeed = horizontal * speedFront;
                //motorFront.motorSpeed = speedButton.Horizontal() * speedFront;
                motorFront.maxMotorTorque = motorTorqueFront;
            }
        }

        else
        {
            if (tractionBack)
            {
                motorBack.motorSpeed = 0 * speedBack;
                motorBack.maxMotorTorque = motorTorqueBack;
            }

            if (tractionFront)
            {
                motorFront.motorSpeed = 0 * speedFront;
                motorFront.maxMotorTorque = motorTorqueFront;
            }
        }*/
       
        
#elif UNITY_IOS || UNITY_ANDROID || UNITY_WP8 || UNITY_IPHONE

        if (!gameController.finishGame)
        {
            if (speedButton.isSpeed)
            {
                //AudioSpeed();
                //Audio();
                if (tractionBack)
                {
                    //motorBack.motorSpeed = horizontal * speedBack;
                    motorBack.motorSpeed = speedButton.Horizontal() * speedBack;
                    motorBack.maxMotorTorque = motorTorqueBack;
                    //print(" motorSpeed : " + speedButton.getValueTorque());
                }

                if (tractionFront)
                {
                    //motorFront.motorSpeed = horizontal * speedFront;
                    motorFront.motorSpeed = speedButton.Horizontal() * speedFront;
                    motorFront.maxMotorTorque = motorTorqueFront;
                }
            }
                


            else if (retreatButton.isSpeed)
            {
                //AudioRetreat();
                if (tractionBack)
                {
                    //motorBack.motorSpeed = horizontal * speedBack;
                    motorBack.motorSpeed = retreatButton.Horizontal() * speedBack;
                    motorBack.maxMotorTorque = motorTorqueBack;
                    print(" motorSpeed : " + speedButton.getValueTorque());
                }

                if (tractionFront)
                {
                    //motorFront.motorSpeed = horizontal * speedFront;
                    motorFront.motorSpeed = retreatButton.Horizontal() * speedFront;
                    motorFront.maxMotorTorque = motorTorqueFront;
                }
            }


            else if (!Input.GetButton("Horizontal"))
            {
                //AudioSkid();
                if (tractionBack)
                {
                    motorBack.motorSpeed = 0 * speedBack;
                    motorBack.maxMotorTorque = motorTorqueBack;
                }

                if (tractionFront)
                {
                    motorFront.motorSpeed = 0 * speedFront;
                    motorFront.maxMotorTorque = motorTorqueFront;
                }
            }
        }
        

        #endif

        wheelBack.motor = motorBack;
        wheelFront.motor = motorFront;
        
    }

    public void AudioEngine()
    {
        audioSurce.clip = audioClipEngine;
        audioSurce.Play();
        
    }

    public void AudioSpeed()
    {
        if (Time.time > nextClipSpeed)
        {
            nextClipSpeed = Time.time + waitForNextClipSpeed;
            audioSurce.clip = audioClipSpeed;
            audioSurce.Play();
            audioSurce.pitch = 3;
        }

        if (Time.time + 0.1 > nextClipSpeed)
        {
            audioSurce.pitch = 2.5f;
        }

        if (Time.time + 0.2 > nextClipSpeed)
        {
            audioSurce.pitch = 2;
        }

        if (Time.time + 0.3 > nextClipSpeed)
        {
            audioSurce.pitch = 1.5f;
        }
        if (Time.time + 0.4 > nextClipSpeed)
        {
            audioSurce.pitch = 1f;
        }
        if (Time.time + 0.5 > nextClipSpeed)
        {
            audioSurce.pitch = 0.5f;
        }
    }

    public void AudioRetreat()
    {
        if (Time.time > nextClipRetreat)
        {
            nextClipRetreat = Time.time + waitForNextClipRetreat;
            audioSurce.clip = audioClipRetreat;
            audioSurce.Play();
        }
    }

    public void AudioSkid()
    {
        if (Time.time > nextClipSkid)
        {
            nextClipSkid = Time.time + waitForNextClipSkid;
            audioSurce.clip = audioClipRetreat;
            audioSurce.Play();
        }
    }

    public void AudioStartEngine()
    {
        audioSurce.clip = audioClipStartEngine;
        audioSurce.Play();

    }

    
}
