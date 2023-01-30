using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class StartMenu : MonoBehaviour
{

[SerializeField] GameObject cameraSwitch;
[SerializeField] CinemachineVirtualCamera camera;
[SerializeField] GameObject UI_Training;
[SerializeField] GameObject UI_Start;
[SerializeField] GameObject Obj;

    // Start is called before the first frame update
public void StartTraining(){
    UI_Start.SetActive(false);
    cameraSwitch.SetActive(true);
    camera.m_Priority = 0;
    UI_Training.SetActive(true);
    Obj.SetActive(true);
    
}

public void QuitApplication(){
    Debug.Log("See ya nexttime");
    
    //for build:
    Application.Quit();
}
}
