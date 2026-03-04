using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraSwitch : MonoBehaviour
{
    // Start is called before the first frame update
    public List<Camera> CList;
    [SerializeField]
    public int enabledIndex = 0;
    void Start()
    {
        CList[0].enabled = true;
        for (int i = 1; i < CList.Count; i++)
        {
            CList[i].enabled = false;
        }
    }

    // Update is called once per frame
    public void NextCamera()
    {
        CList[enabledIndex].enabled = false;// disable active camera.
        enabledIndex = (enabledIndex + 1) % CList.Count; // calculate next camera index
        CList[enabledIndex].enabled = true; // enable new camera
    }

    public void EnableIndex(int indexToEnable)
    {
        CList[enabledIndex].enabled = false; // disable active camera.
        enabledIndex = indexToEnable % CList.Count; // calculate camera to enable
        CList[enabledIndex].enabled = true; // enable new camera

    }
}