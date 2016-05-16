using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PinballController : MonoBehaviour {

    [SerializeField]
    private GameObject Ball;
    [SerializeField]
    private Transform OriginalBallPos;

    private bool gameOver = false;
    private bool increasing;
    private bool wasShot;
    private float Power;


    // Use this for initialization
    void Start ()
    {
        Ball.GetComponent<Rigidbody>().maxAngularVelocity = 75.0f;
        //increasing = false;
        wasShot = false;
	}
	
	// Update is called once per frame
	void Update ()
    {
	
	}

    void FixedUpdate ()
    {
        if (Input.GetButton("Restart") && gameOver)
        {
            Debug.Log("Got R");
            wasShot = false;
            Ball.transform.position = OriginalBallPos.position;
            Ball.GetComponent<Rigidbody>().velocity = Vector3.zero;
        }

    }
    public void SetGameOver()
    {
        gameOver = true;
    }
}
