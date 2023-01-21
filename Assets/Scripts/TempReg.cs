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

    void Awake()
    {
        gameManager = FindObjectOfType<GameManager>();
    }

    public override void OnClick()
    {
        base.OnClick();
        adjustable = true;
        tongsContainer.SetActive(false);

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
        // Debug.Log("DAKJSLÖDJSALKJDALKSJDLKAJDLKWAJDWJLKWAJDÖLWAJöd");
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
        adjustable = false;
        gameManager.SetNextSection();
        Debug.Log("nopedidy");
        CameraSwitch.Instance.SwitchCamera (temperCam);
        tongsContainer.SetActive(true);
    }
}
