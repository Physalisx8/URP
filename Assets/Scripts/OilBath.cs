using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OilBath : InteractableObject
{
    [SerializeField] ParticleSystem smoke;
    Animator animator;
    GameObject knife;
    void Awake()
    {
        gameManager = FindObjectOfType<GameManager>();
        knife = GameObject.Find("knife");
        animator = knife.GetComponent<Animator>();
    }
    void Start()
    {
        // ParticleSystem smoke = GameObject.Find("Smoke").GetComponent<ParticleSystem>();

    }
    GameManager gameManager;


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

    public IEnumerator waitToStop(float seconds)
    {
        yield return new WaitForSeconds(seconds);
        smoke.Stop();
    }

    public IEnumerator waitToStart(float seconds)
    {
        yield return new WaitForSeconds(seconds);
        smoke.Play();
    }

    public void KnifeDips()
    {
        //onClick Animation Messer reinhalten abspielen, dann wenn das Messer einetaucht ist den Rauch aufsteigen lassen.

        GameObject quenchCont = GameObject.Find("QuenchContainer");
        quenchCont.GetComponent<Animator>().Play("quench");
        StartCoroutine(waitToStart(0.47f));

        //smoke.Play();
        animator.Play("chillOff");
        StartCoroutine(waitToStop(2f));

        
        /*
        anim ["cubeanimation"].speed = -1;
           anim ["cubeanimation"].time = anim ["cubeanimation"].length;
           anim.Play ("cubeanimation");
           Cooling Off Animation spielen
           wir müssen dann vmtl abfragen wann die coolingOff Animation des Messers fertig ist, um dann die rauszieh animation spielen zu können und die Particel wieder zu pausen
           Mangelnder Realismus weil keiner Bock hat die Partikel weniger zu machen, je kühler es wird.. 
        */

    }

    //private void OnTriggerEnter(Collider other)
    //{
    //    Debug.Log(other.transform.name);
    //    if(other.transform.name.Equals("Knife")) {
    //        smoke.Play();

    //    }
    //}

}