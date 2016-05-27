using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PinballController : MonoBehaviour {

    [SerializeField]
    private GameObject Ball;
    [SerializeField]
    private Transform OriginalBallPos;

    [SerializeField]
    private GameObject Plunger;

    [SerializeField]
    private Transform PullPos;
    [SerializeField]
    private Transform StartPos;
    [SerializeField]
    private float Speed = 1.0f;
    [SerializeField]
    private float PullPower = 400.0f;
    [SerializeField]
    private float MaxPower = 500.0f;
    [SerializeField]
    private Slider PowerBar;
    [SerializeField]
    private GameObject LeftFlipper;
    [SerializeField]
    private GameObject RightFlipper;

    [SerializeField]
    private GameObject BallStop;

    private bool gameOver = false;
    private float stuckTime = 0.0f;
    private bool wasShot;

    private float Power = 0;
    private float ResetVal = 0;
    public bool ready = false;
    private bool fire = false;
    private bool increasing = false;
    // Use this for initialization
    void Start ()
    {

	}

    void Awake ()
    {
        Ball.GetComponent<Rigidbody>().maxAngularVelocity = 100.0f;
        //increasing = false;
        wasShot = false;

        ready = false;
        fire = false;
        StartPos.gameObject.SetActive(false);
        PullPos.gameObject.SetActive(false);
        BallStop.SetActive(false);
    }
	
	// Update is called once per frame
	void Update ()
    {

    }

    void FixedUpdate ()
    {
        if (Input.GetButton("Restart") && ( gameOver || stuckTime >= 3.0f ))
        {
            Debug.Log("Got R");
            Debug.Log(stuckTime);
            stuckTime = 0;
            wasShot = false;
            Ball.transform.position = OriginalBallPos.position;
            Ball.GetComponent<Rigidbody>().velocity = Vector3.zero;
            BallStop.SetActive(false);
        }

        if (Input.GetButton("Jump"))
        {
            //Debug.Log("Pull down...");
            if (Vector3.Distance(Plunger.transform.position, PullPos.transform.position) > Speed * Time.deltaTime)
            {
                Plunger.transform.Translate(0, -Speed * Time.deltaTime, 0, Space.Self);
            }
            fire = true;
            increasing = true;
        }
        //else if (Input.GetButtonUp("Jump"))
        else if (Vector3.Distance(Plunger.transform.position, StartPos.transform.position) > Speed * 8 * Time.deltaTime)
        {
            //Debug.Log("Pull up...");
            if (fire && ready)
            {
                Debug.Log(Power);
                Ball.GetComponent<Rigidbody>().AddForce(Vector3.forward * Power * 1.0f);
                fire = false;
                ready = false;
                increasing = false;
                Power = 0.0f;
            }
            if (Vector3.Distance(Plunger.transform.position, StartPos.transform.position) > Speed * 8 * Time.deltaTime)
                Plunger.transform.Translate(0, Speed * 8 * Time.deltaTime, 0, Space.Self);
        }

        PowerBar.value = Power;

        if (increasing)
        {
            Power += Time.deltaTime * PullPower;
            Power = Mathf.Clamp(Power, 0, MaxPower);
        }

        if(Input.GetButton("A"))
        {
            HingeJoint hin = LeftFlipper.GetComponent<HingeJoint>();
            JointMotor jm = hin.motor;
            jm.force = 5000;
            jm.targetVelocity = -1200;
            jm.freeSpin = false;
            hin.motor = jm;
            hin.useMotor = true;
        }
        else
        {
            HingeJoint hin = LeftFlipper.GetComponent<HingeJoint>();
            JointMotor jm = hin.motor;
            jm.force = 5000;
            jm.targetVelocity = 800;
            jm.freeSpin = false;
            hin.motor = jm;
            hin.useMotor = true;
        }
        if (Input.GetButton("D"))
        {
            HingeJoint hin = RightFlipper.GetComponent<HingeJoint>();
            JointMotor jm = hin.motor;
            jm.force = 5000;
            jm.targetVelocity = 1200;
            jm.freeSpin = false;
            hin.motor = jm;
            hin.useMotor = true;
        }
        else
        {
            HingeJoint hin = RightFlipper.GetComponent<HingeJoint>();
            JointMotor jm = hin.motor;
            jm.force = 5000;
            jm.targetVelocity = -800;
            jm.freeSpin = false;
            hin.motor = jm;
            hin.useMotor = true;
        }

        if (Ball.GetComponent<Rigidbody>().angularVelocity == Vector3.zero)
        {
            stuckTime += Time.deltaTime;
        }

    }
    public void SetGameOver()
    {
        gameOver = true;
    }

    public void StopBall()
    {
        BallStop.SetActive(true);
    }
}
