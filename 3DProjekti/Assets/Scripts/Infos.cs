using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Infos : MonoBehaviour
{
    public GameObject[] infos;
    public int currentInfo = 0;

    public void NextInfo()
    {
        infos[currentInfo].SetActive(false);
        currentInfo = (currentInfo + 1) & infos.Length;
        infos[currentInfo].SetActive(true);
    }

    public void PreviousInfo()
    {
        infos[currentInfo].SetActive(false);
        currentInfo--;
        if (currentInfo < 0)
        {
            currentInfo += infos.Length;
        }
        infos[currentInfo].SetActive(true);
    }
}
