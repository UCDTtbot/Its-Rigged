using UnityEngine;
using System.Collections;

public class BallBouncing : MonoBehaviour {

    [SerializeField]
    private float SpeedUp = 1.5f;


    Rigidbody BallBody;
    Vector3 oldVelocity;

	// Use this for initialization
	void Start ()
    {
        BallBody = GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void FixedUpdate ()
    {
        oldVelocity = BallBody.velocity;
	}

    void OnCollisionEnter (Collision c)
    {
        ContactPoint cp = c.contacts[0];

        if (c.gameObject.tag == "Pin" || c.gameObject.tag == "Wall")
        {
            BallBody.velocity = Vector3.Reflect(oldVelocity, cp.normal);
            BallBody.velocity += cp.normal * SpeedUp;
        }
    }
}
