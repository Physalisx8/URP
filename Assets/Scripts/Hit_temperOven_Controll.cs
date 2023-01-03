using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hit_temperOven_Controll : MonoBehaviour
{
  [SerializeField] private Animator doorAnimation = null;
  private bool temperOven_open = false;
  [SerializeField] private string openAnimationName = "temper_oven_open";
  [SerializeField] private string closeAnimationName = "temper_oven_close";
  [SerializeField] private int waitTimer = 1;
  [SerializeField] private bool pauseInteraction = false;

  private IEnumerator PauseDoorInteraction(){
    pauseInteraction = true;
    yield return new WaitForSeconds(waitTimer);
    pauseInteraction= false;
  }

  public void PlayAnimation(){
    if(!temperOven_open && !pauseInteraction){
        doorAnimation.Play(openAnimationName, 0,0.0f);
        temperOven_open = true;
        StartCoroutine(PauseDoorInteraction());
    }
     else if(temperOven_open && !pauseInteraction){
        doorAnimation.Play(closeAnimationName, 0,0.0f);
        temperOven_open = false;
        StartCoroutine(PauseDoorInteraction());
    }
  }
}
