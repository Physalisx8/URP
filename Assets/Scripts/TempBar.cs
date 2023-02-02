using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//[ExecuteInEditMode()]

//ToDo: increase current over time
public class TempBar : MonoBehaviour
{
    
    
   [SerializeField] GameObject _GO;
   [SerializeField] GameObject _UI;
private int maximum = 15;
float fillAmount;

  float elapsedTime= 0;
public Image temp;

bool window;
bool stap;
  GameManager gameManager;
void Start(){
    //TemperatureRise dann irgendwann callen, wenn wir wissen wo.
    TemperatureRise();
    //ToDo: wir müssen unbedingt die UI dann auch enablen, sonst sieht man ja nix.
}
    void Awake(){
        gameManager = FindObjectOfType<GameManager>();
    }

void Update(){

if(!window){
        if(Input.GetMouseButtonDown(0)){
            gameManager.IncreaseErrorCounter();
        }
    }
//if Flag, then check for input from User, if Input comes, Stop animation and set flag for Stopping Coroutine
    if (window){
           if(Input.GetMouseButtonDown(0)){
             _GO.GetComponent<Animator>().enabled = false;
             stap = true;
             _UI.SetActive(false);
    }
    
       
}}


//checking timeframe from temperature Bar & sets Flag
void CheckInput(float amount){
        if (amount > 0.397 && amount < 0.52){
             window= true;
             }
        else if(amount <= 0.397 || amount >=0.52){
            window=false;
        }
}

//starting Coroutine to fill up the TemperatureBar, start Animation
   public void TemperatureRise(){
        _UI.SetActive(true);
        StartCoroutine(IncreaseSeconds(maximum));
        _GO.GetComponent<Animator>().Play("changeEmission");
        }
        
    
//Coroutine to increase the Temperature Bar.
public IEnumerator IncreaseSeconds (float seconds){

    while (elapsedTime < seconds && !stap){
        elapsedTime += Time.deltaTime;
        fillAmount = elapsedTime/seconds;
        CheckInput(fillAmount);
        temp.fillAmount = fillAmount;
      
          
        yield return new WaitForEndOfFrame();
    
    }

    //stops coroutine and sets fillAmount with last known fill
    if (stap){
    temp.fillAmount = fillAmount;}

    //looping it in case User failed to click while window was open
    else {
        temp.fillAmount = 0;
        stap=false;
        elapsedTime=0;
        TemperatureRise();
    }
}

    
}
