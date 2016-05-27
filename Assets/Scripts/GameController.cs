using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GameController : MonoBehaviour {

    //Camera Variables
    [SerializeField]
    private Camera MainCamera;
    [SerializeField]
    private Transform Init_Pos;
    [SerializeField]
    private float Camera_Move_Time = 2.0f;
    [SerializeField]
    private Transform[] Camera_Pos = new Transform[2];
    [SerializeField]
    private string[] Game_Name = new string[2];

    //Menu Variables
    [SerializeField]
    private GameObject MainMenu;
    [SerializeField]
    private GameObject GameSelect;

    //Game Scripts
    [SerializeField]
    private GameObject[] Game_Controllers = new GameObject[2];

    //Spaghetti Code Fuck
    [SerializeField]
    private int PinballPos;

    private float waitTime = 1.0f;
    private int curPos = -1;
    private int nextPos = -1;
    private Vector3 Camera_Move_Velocity = Vector3.zero;
    private bool camMoving = false;

    // Use this for initialization
    void Start ()
    {

    }

    void Awake ()
    {
        curPos = 0;
        nextPos = 0;
        MainMenu.SetActive(true);
        GameSelect.SetActive(false);
        MainCamera.transform.position = Init_Pos.transform.position;
        for (int i = 0; i < Game_Controllers.Length; i++)
            Game_Controllers[i].SetActive(false);
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
        GameSelect.GetComponentInChildren<Text>().text = Game_Name[curPos];
    }

    public void ExitGame()
    {
        Application.Quit();
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
            GameSelect.GetComponentInChildren<Text>().text = Game_Name[curPos];
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
            GameSelect.GetComponentInChildren<Text>().text = Game_Name[curPos];
        }
    }

    public void StartArcadeGame()
    {
        Game_Controllers[curPos].SetActive(true);
        GameSelect.SetActive(false);
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
