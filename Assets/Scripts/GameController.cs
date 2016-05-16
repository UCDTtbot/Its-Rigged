using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour {

    [SerializeField]
    private Camera MainCamera;
    [SerializeField]
    private Transform Test_Start_Pos;
    [SerializeField]
    private Transform Test_End_Pos;
    [SerializeField]
    private Vector3 Camera_Move_Velocity = Vector3.zero;
    [SerializeField]
    private float Camera_Move_Speed = 2.0f;


    private float waitTime = 5;

	// Use this for initialization
	void Start ()
    {
        MainCamera.transform.position = Test_Start_Pos.transform.position;
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (waitTime <= 0)
            MainCamera.transform.position = Vector3.SmoothDamp(MainCamera.transform.position, Test_End_Pos.position, ref Camera_Move_Velocity, Camera_Move_Speed);
        else
            waitTime--;


        //void Update() {
        //    float yAngle = Mathf.SmoothDampAngle(transform.eulerAngles.y, target.eulerAngles.y, ref yVelocity, smooth);
        //    Vector3 position = target.position;
        //    position += Quaternion.Euler(0, yAngle, 0) * new Vector3(0, 0, -distance);
        //    transform.position = position;
        //    transform.LookAt(target);
        //}

    }
}
