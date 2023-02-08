using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OilBath : InteractableObject
{
    [SerializeField] ParticleSystem smoke;
    Animator animator;
    [SerializeField] GameObject knife;
    GameObject quenchContainer;
    GameManager gameManager;

    void Awake()
    {
        gameManager = FindObjectOfType<GameManager>();
        //knife = GameObject.Find("knife");
        quenchContainer = GameObject.Find("QuenchContainer");

        animator = knife.GetComponent<Animator>();
    }

    public override void SectionChange(SectionState state)
    {
        base.SectionChange(state);

        switch (state)
        {
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

    void Reset()
    {
        if (debug)
            Debug.Log("Reset");
              quenchContainer.GetComponent<Animator>().Play("idle");
            smoke.Stop();
            animator.Play("sevenSec");
            animator.enabled = false;
          
    }

    public override void OnClick()
    {
        base.OnClick(); // Immer den BUms hier ausführen

        // Your code what happens on a click
        if (gameManager != null)
        {
            if (!isInteractable)
            {
                gameManager.IncreaseErrorCounter();
            }
            else
            {
                KnifeDips();
                gameManager.SetNextSection();
            }
        }
        else
        {
            if (debug)
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


    public IEnumerator waitToStart(float seconds)
    {
        yield return new WaitForSeconds(seconds);
        smoke.Play();

        //yield return new WaitForSeconds(quenchContainer.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).length
        //    + (quenchContainer.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).normalizedTime % 1));
        yield return new WaitForSeconds(1.5f);
        enableAnimator();

        yield return new WaitForSeconds(1f);
        smoke.Stop();
        if (debug)
            Debug.Log(animator.GetCurrentAnimatorClipInfo(0).Length);

        yield return new WaitWhile(()=> animator.GetCurrentAnimatorStateInfo(0).normalizedTime <= 1);
        disableAnimator();

       // yield return new WaitWhile(() => animator.isActiveAndEnabled);
        quenchContainer.GetComponent<Animator>().SetTrigger("returnQuench");
        
    }


    private void disableAnimator()
    {
        animator.enabled = false; 
    }

    private void enableAnimator()
    {
        animator.enabled = true;
        animator.Play("coolingOff");
    }

    public void KnifeDips()
    {
        //onClick Animation Messer reinhalten abspielen, dann wenn das Messer einetaucht ist den Rauch aufsteigen lassen.

        knife = GameObject.Find("knife");

        quenchContainer.GetComponent<Animator>().SetTrigger("quenching");
        StartCoroutine(waitToStart(1f));

        /*
        anim ["cubeanimation"].speed = -1;
           anim ["cubeanimation"].time = anim ["cubeanimation"].length;
           anim.Play ("cubeanimation");
           Cooling Off Animation spielen
           wir müssen dann vmtl abfragen wann die coolingOff Animation des Messers fertig ist, um dann die rauszieh animation spielen zu können und die Particel wieder zu pausen
           Mangelnder Realismus weil keiner Bock hat die Partikel weniger zu machen, je kühler es wird.. 
        */

    }
}