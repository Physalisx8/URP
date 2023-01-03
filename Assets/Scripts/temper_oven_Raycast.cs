using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class temper_oven_Raycast : MonoBehaviour
{
    [SerializeField] private int rayLength = 5;
    [SerializeField] private LayerMask layerMaskInteract;
    [SerializeField] private string excludeLayerName = null;

    private Hit_temperOven_Controll raycastedObj;
    [SerializeField] private KeyCode openDoorKey = KeyCode.Mouse0;
  
    private bool doOnce;
    private const string interactableTag = "inv_Handle";

    private void Update(){
        RaycastHit hit;
        Vector3 fwd = transform.TransformDirection(Vector3.forward);
        int mask = 1 <<LayerMask.NameToLayer(excludeLayerName) | layerMaskInteract.value;

        if(Physics.Raycast(transform.position, fwd, out hit, rayLength, mask)){
            if(hit.collider.CompareTag(interactableTag)){
                if(!doOnce){
                    raycastedObj = hit.collider.gameObject.GetComponent<Hit_temperOven_Controll>();
                }
                doOnce = true;

                if(Input.GetKeyDown(openDoorKey)){
                    raycastedObj.PlayAnimation();
                }
            }
        }

       
    
    

    } 
}
