using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pause : MonoBehaviour
{
    public void pausetime()
    {
        Time.timeScale = 0;
    }
    public void resumetime()
    {
        Time.timeScale = 1;
    }
}
