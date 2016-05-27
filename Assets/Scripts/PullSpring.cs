using UnityEngine;
using System.Collections;
using UnityEngine.UI;


public class PullSpring : MonoBehaviour {

    //[SerializeField]
    //private Transform PullPos;
    //[SerializeField]
    //private Transform StartPos;
    //[SerializeField]
    //private float Speed = 1.0f;
    //[SerializeField]
    //private float PullPower = 400.0f;
    //[SerializeField]
    //private GameObject Ball;
    //[SerializeField]
    //private float MaxPower = 500.0f;
    //[SerializeField]
    //private Slider PowerBar;


    //private float Power = 0;
    //private float ResetVal = 0;
    //private bool ready = false;
    //private bool fire = false;
    //private bool increasing = false;

    [SerializeField]
    private PinballController control;

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Ball")
        {
            control.ready = true;
            Debug.Log("Collision");
        }
    }

	// Use this for initialization
	void Start ()
    {

	}

    void Awake ()
    {
        //ready = false;
        //fire = false;
        //StartPos.gameObject.SetActive(false);
        //PullPos.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update ()
    {
        //if (Input.GetButton("Jump"))
        //{
        //    //Debug.Log("Pull down...");
        //    if( Vector3.Distance(transform.position, PullPos.transform.position) > Speed * Time.deltaTime)
        //    {
        //        transform.Translate(0, -Speed * Time.deltaTime, 0, Space.Self);
        //    }
        //    fire = true;
        //    increasing = true;
        //}
        ////else if (Input.GetButtonUp("Jump"))
        //else if(Vector3.Distance(transform.position, StartPos.transform.position) > Speed * 8 * Time.deltaTime)
        //{
        //    //Debug.Log("Pull up...");
        //    if (fire && ready)
        //    {
        //        Debug.Log(Power);
        //        Ball.GetComponent<Rigidbody>().AddForce(Vector3.forward * Power * 1.0f);
        //        fire = false;
        //        ready = false;
        //        increasing = false;
        //        Power = 0.0f;
        //    }
        //    if (Vector3.Distance(transform.position, StartPos.transform.position) > Speed * 8 * Time.deltaTime)
        //        transform.Translate(0, Speed * 8 * Time.deltaTime, 0, Space.Self);
        //}

        //PowerBar.value = Power;

        //if (increasing)
        //{
        //    Power += Time.deltaTime * PullPower;
        //    Power = Mathf.Clamp(Power, 0, MaxPower);
        //}
	}

}
