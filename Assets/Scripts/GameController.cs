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
    [SerializeField]
    private GameObject GameSelect;


    private float waitTime = 1.0f;
    private int curPos = -1;
    private int nextPos = -1;
    private Vector3 Camera_Move_Velocity = Vector3.zero;
    private bool camMoving = false;

    // Use this for initialization
    void Start ()
    {
        MainMenu.SetActive(true);
        GameSelect.SetActive(false);
        MainCamera.transform.position = Init_Pos.transform.position;
        curPos = 0;
        nextPos = 0;
	}
	
	// Update is called once per frame
	void Update ()
    {

    }

    public void StartGame()
    {
        curPos = 0;
        MainMenu.SetActive(false);
        StartCoroutine(MoveCamera(Init_Pos, Camera_Pos[curPos], Camera_Move_Time));
        GameSelect.SetActive(true);
    }

    public void NextGame()
    {
        if (!camMoving)
        {
            nextPos = curPos + 1;
            if (nextPos >= Camera_Pos.Length)
                nextPos = 0;
            Debug.Log(curPos);
            Debug.Log(nextPos);
            StartCoroutine(MoveCamera(Camera_Pos[curPos], Camera_Pos[nextPos], Camera_Move_Time));
            curPos = nextPos;
        }
    }

    public void PreviousGame()
    {
        if (!camMoving)
        {
            nextPos = curPos - 1;
            if (nextPos < 0)
                nextPos = 3;
            Debug.Log(curPos);
            Debug.Log(nextPos);
            StartCoroutine(MoveCamera(Camera_Pos[curPos], Camera_Pos[nextPos], Camera_Move_Time));
            curPos = nextPos;
        }
    }

    public IEnumerator MoveCamera(Transform Cur_Pos, Transform Next_Pos, float time)
    {
        float elapsedTime = 0;
        camMoving = true;
        while (elapsedTime < time)
        {
            //MainCamera.transform.position = Vector3.SmoothDamp(MainCamera.transform.position, Camera_Pos[curPos].position, ref Camera_Move_Velocity, (elapsedTime / time));
            MainCamera.transform.position = Vector3.Lerp(Cur_Pos.position, Next_Pos.position, (elapsedTime / time));
            MainCamera.transform.rotation = Quaternion.Lerp(Cur_Pos.rotation, Next_Pos.rotation, (elapsedTime / time));
            elapsedTime += Time.deltaTime;
            yield return new WaitForEndOfFrame();
        }
        camMoving = false;
    }

}
