using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pause : MonoBehaviour
{
    private bool isPause = false;
    public void OnClickButton()
    {
        if(isPause == false) 
        {
            Time.timeScale = 0;
            isPause = true;
            return;
        }
        if(isPause == true)
        {
            Time.timeScale = 1;
            isPause = false;
            return;
        }
    }
}
