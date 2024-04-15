using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ExitApp : MonoBehaviour
{
    public void OnExit()
    {
        Debug.Log("Exit pressed!!!");
        Application.Quit();
    }
}
