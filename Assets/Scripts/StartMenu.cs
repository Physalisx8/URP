using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using Cinemachine;

public class StartMenu : MonoBehaviour
{

[SerializeField] GameObject cameraSwitch;
[SerializeField] CinemachineVirtualCamera camera;
[SerializeField] GameObject UI_Training;
[SerializeField] GameObject UI_Demo;
[SerializeField] GameObject UI_Start;
[SerializeField] GameObject UI_End;
[SerializeField] GameObject Obj;

[SerializeField] GameObject[] stabbing;

[SerializeField] GameManager gameManager;
bool demo;

    // Start is called before the first frame update
public void StartTraining(){
    UI_Start.SetActive(false);
    cameraSwitch.SetActive(true);
    camera.m_Priority = 0;
    UI_Training.SetActive(true);
    Obj.SetActive(true);
    UI_Demo?.SetActive(false);
}

public void StartDemoMode(){

    StartTraining();
    Obj.SetActive(false);
   demo = true;
   /* stabbing[0].SetActive(false);
    stabbing[1].SetActive(false);
    stabbing[2].SetActive(false);
    stabbing[3].SetActive(false);
    */
    
    UI_Demo?.SetActive(true);
}

//very hacky aber whatever 
/*
void Update(){
if (demo){
    stabbing[2].SetActive(false);
    stabbing[4].SetActive(false);}}*/

public void StartApp(){
    SceneManager.LoadScene(SceneManager.GetActiveScene().name);
}

public void QuitApplication(){
    Debug.Log("See ya nexttime");
    
    //for build:
    Application.Quit();
}

public void EndDemonstrator(){
    Debug.Log("This is where we should end");
    cameraSwitch.SetActive(false);
    camera.m_Priority = 2;
    UI_Training.SetActive(false);
    UI_End.SetActive(true);
    UI_Demo?.SetActive(false);
    Obj.SetActive(false);

}
}
