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

    // Start is called before the first frame update
public void StartTraining(){
    UI_Start.SetActive(false);
    cameraSwitch.SetActive(true);
    camera.m_Priority = 0;
    UI_Training.SetActive(true);
    
}
}
