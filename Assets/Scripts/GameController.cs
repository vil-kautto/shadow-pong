using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public void StartRound()
    {

        Debug.Log("Round Start");
    }

    public void EndRound()
    {
        Debug.Log("Round End");
        StartRound();
    }
}
