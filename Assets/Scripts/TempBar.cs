using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//[ExecuteInEditMode()]

//ToDo: increase current over time
public class TempBar : MonoBehaviour
{
    
public int maximum;
public Image temp;

void Start(){
    //StartCoroutine(IncreaseSeconds(maximum));
}


void CheckInput(float amount){
    if (amount >= 0.397 && amount <=0.52){
        Debug.Log("hwoa");

    }
    
}

public IEnumerator IncreaseSeconds (float seconds){
    float elapsedTime= 0;
    while (elapsedTime < seconds){
         elapsedTime += Time.deltaTime;
        float fillAmount = elapsedTime/seconds;
        CheckInput(fillAmount);
        temp.fillAmount = fillAmount;
          
        yield return new WaitForEndOfFrame();
    
    }
    temp.fillAmount = 0;
}

    
}
