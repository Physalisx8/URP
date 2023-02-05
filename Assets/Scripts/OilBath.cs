using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OilBath : InteractableObject
{
[SerializeField] ParticleSystem smoke;
  Animator animator;
  GameObject knife;
  GameManager gameManager;
        void Awake(){
        gameManager = FindObjectOfType<GameManager>();
        knife = GameObject.Find("knife");
        animator = knife.GetComponent<Animator>();
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
        base.OnClick(); // Immer den BUms hier ausführen

        // Your code what happens on a click
        if (gameManager != null)
        {
            if (!isInteractable){
                gameManager.IncreaseErrorCounter();
            }
            else{
                KnifeDips();
                
            }
        } else {
            Debug.Log("gameManager = null");
        }
        
        
    }

    public override void HoverStart()
    {
        // Your Code
        base.HoverStart();
    }

        public override void HoverStop()
    {
        // Your Code
        base.HoverStop();
    }

    public IEnumerator wait()
    {   Debug.Log("Why no?!");

        yield return new WaitForSeconds(2);
        
        smoke.Stop();
        gameManager.SetNextSection();

    }

  
    public void KnifeDips(){
        //onClick Animation Messer reinhalten abspielen, dann wenn das Messer einetaucht ist den Rauch aufsteigen lassen.
                smoke.Play();
                animator.SetTrigger("coolOff");
                StartCoroutine(wait());
         /*
    
            wir müssen dann vmtl abfragen wann die coolingOff Animation des Messers fertig ist, um dann die rauszieh animation spielen zu können und die Particel wieder zu pausen
            Mangelnder Realismus weil keiner Bock hat die Partikel weniger zu machen, je kühler es wird.. 
         */

    }

}