using UnityEngine;
using System.Collections;

public class PinBallGameOver : MonoBehaviour {

    [SerializeField]
    private PinballController PinballController;

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Ball")
        {
            PinballController.SetGameOver();
            Debug.Log("GameOver");
        }
    }
}
