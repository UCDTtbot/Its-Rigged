using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour {

    [SerializeField]
    private Camera MainCamera;
    [SerializeField]
    private Transform Init_Pos;
    [SerializeField]
    private Transform[] Camera_Pos = new Transform[4];
    [SerializeField]
    private float Camera_Move_Time = 2.0f;
    [SerializeField]
    private GameObject MainMenu;


    private float waitTime = 1.0f;
    private int curPos = -1;
    private Vector3 Camera_Move_Velocity = Vector3.zero;

    // Use this for initialization
    void Start ()
    {
        MainMenu.SetActive(true);
        MainCamera.transform.position = Init_Pos.transform.position;
        curPos = 0;
	}
	
	// Update is called once per frame
	void Update ()
    {

    }

    public void StartGame()
    {
        curPos = 0;
        MainMenu.SetActive(false);
        StartCoroutine(MoveCamera(Camera_Pos[curPos], Camera_Move_Time));
    }

    public IEnumerator MoveCamera(Transform Next_Pos, float time)
    {
        float elapsedTime = 0;

        while (elapsedTime < time)
        {
            //MainCamera.transform.position = Vector3.SmoothDamp(MainCamera.transform.position, Camera_Pos[curPos].position, ref Camera_Move_Velocity, (elapsedTime / time));
            MainCamera.transform.position = Vector3.Lerp(MainCamera.transform.position, Next_Pos.position, (elapsedTime / time));
            MainCamera.transform.rotation = Quaternion.Lerp(MainCamera.transform.rotation, Next_Pos.rotation, (elapsedTime / time));
            elapsedTime += Time.deltaTime;
            yield return new WaitForEndOfFrame();
        }
    }

}
