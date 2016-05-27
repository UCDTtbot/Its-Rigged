using UnityEngine;
using System.Collections;

public class BallStopper : MonoBehaviour {

    [SerializeField]
    private PinballController PinballController;

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Ball")
        {
            PinballController.StopBall();
        }

    }

}
