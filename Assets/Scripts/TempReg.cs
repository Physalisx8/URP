using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using TMPro;
using UnityEngine;

// Von InteractableObject erben lassen
public class TempReg : CameraTriggerZone
{
    GameManager gameManager;

    [SerializeField]
    bool adjustable;

    [SerializeField]
    TextMeshPro text;

    [SerializeField]
    GameObject Obj;

    private int increasing = 0;

    private string stringy;

    [SerializeField]
    CinemachineVirtualCamera temperCam;

    [SerializeField]
    GameObject tongsContainer;

    [SerializeField] GameObject empties;

    [SerializeField]
    GameObject UI_;

    void Awake()
    {
        gameManager = FindObjectOfType<GameManager>();
    }

     public override void SectionChange(SectionState state)
    {
        base.SectionChange(state);

        switch (state){
            case SectionState.Start:
            if (debug)
                Debug.Log("START");
            Reset();
            break;
            case SectionState.End:
                OnClick();
            break;
        }
    }

    void Reset(){
        if (debug)
            Debug.Log("Reset");
           
    }


    public override void OnClick()
    {
        base.OnClick();
        adjustable = true;
        tongsContainer.SetActive(false);
        UI_.SetActive(true);
        GetComponent<Collider>().enabled = false;
        

        if (gameManager != null)
        {
            if (!isInteractable)
            {
                gameManager.IncreaseErrorCounter();
            }
        }
        else
        {
            Debug.Log("gameManager = null");
        }
    }

    public void Update()
    {
        if (adjustable)
        {
            changeTemperature();

            //triggers stopIncrease when rechtsklick, vll was anderes mit UI?
            if (Input.GetMouseButtonDown(0) && increasing == 220)
            {
                StopInc();
            }
            if (Input.GetMouseButtonDown(0) && increasing != 220)
            {
                gameManager.IncreaseErrorCounter();
            }
        }
    }

    public void changeTemperature()
    {
        if (
            Input.GetAxis("Mouse ScrollWheel") > 0 &&
            increasing >= 0 &&
            increasing < 750
        )
        {
            Obj.transform.Rotate(Vector3.back * 10f, Space.Self);

            increasing += 10;
            text.SetText(increasing + "°");
        }
        if (
            Input.GetAxis("Mouse ScrollWheel") < 0 &&
            increasing > 0 &&
            increasing <= 750
        )
        {
            Obj.transform.Rotate(Vector3.forward * 10f, Space.Self);

            increasing -= 10;
            text.SetText(increasing + "°");
        }
    }

    public void StopInc()
    {
        GameObject.Find("Clock").GetComponent<Animator>().enabled = true;
        GameObject.Find("Clock").GetComponent<Animator>().Play("clock");
        UI_.SetActive(false);
        adjustable = false;
        CameraSwitch.Instance.SwitchCamera (temperCam);
        tongsContainer.SetActive(true);
        gameManager.SetNextSection();
        empties.transform.position = new Vector3(-1.24f,1.5f,4.17f);
        Debug.Log("nopedidy");
       
    }
}
