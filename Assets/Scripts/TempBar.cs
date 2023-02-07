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
    [SerializeField] CanvasGroup _UI2;
    

    private int maximum = 15;
    float fillAmount;

    public bool demo = false;

    float elapsedTime = 0;
    public Image temp;

    bool window;
    bool stap;


    Animator animator;
    GameManager gameManager;
    GameObject door;
    


    void Start()
    {
        //TemperatureRise dann irgendwann callen, wenn wir wissen wo.
        //TemperatureRise();
        //ToDo: wir müssen unbedingt die UI dann auch enablen, sonst sieht man ja nix.
    }
    void Awake()
    {
        gameManager = FindObjectOfType<GameManager>();
        door = GameObject.Find("Door");
        animator = door.GetComponent<Animator>();
    }

    void Update()
    {

        

        if (!window)
        {
            if (Input.GetMouseButtonDown(0) && _UI2.alpha==1)
            {
                gameManager.IncreaseErrorCounter();
            }
        }
        //if Flag, then check for input from User, if Input comes, Stop animation and set flag for Stopping Coroutine
        if (window)
        {
            if ((Input.GetMouseButtonDown(0) || demo) && _UI2.alpha ==1 )
            {
                Successfull();
            }


        }
    }

    public void OnDemo(bool check)
    {
        if (check)
        {
            demo = true;
        }
        else
        {
            demo = false;
        }
    }
    void Successfull()
    {

        GameObject.Find("Door").GetComponent<BoxCollider>().enabled = true;
        _GO.GetComponent<Animator>().enabled = false;
        //_GO.GetComponent<Animator>().SetTrigger("paused");
        stap = true;
        //_UI.SetActive(false);
        _UI2.alpha = 0f;
        animator.SetTrigger("OpenDoor");

        OnDemo(false);
       

        /*
        _UI2.SetActive(false);
        image = GetComponent<Image>();
          var tempColor = image.color;
          tempColor.a = 1f;
          image.color = tempColor;
        */
    
    }

    //checking timeframe from temperature Bar & sets Flag
    void CheckInput(float amount)
    {
        window = amount > 0.397 && amount < 0.52;
    }

    //starting Coroutine to fill up the TemperatureBar, start Animation
    public void TemperatureRise()
    {
        // _UI.SetActive(true);
        StartCoroutine(IncreaseSeconds(maximum));
        _GO.GetComponent<Animator>().Play("changeEmission");

        //Animationen anpsrechen:
        // 1. Spielt Animation direkt ab ohne transition von der jetzigen
        // Animator.Play("AnimationsName"); 
        // 2. Ändert Condition, wenn alle Conditions erfüllt sind macht er ne Transition
        // Animator.SetTrigger("TriggerName");
        // Animation.SetFloat("FloatName", 5);
    }

    public void Reset()
    {
        StopAllCoroutines();
        temp.fillAmount = 0;
        elapsedTime = 0;
        stap = false;
        _GO.GetComponent<Animator>().enabled = true;
        //ToDO Leiv dass er das machen muss :)
        _GO.GetComponent<Animator>().Play("chill");
        // Animation Resetten!
    }


    //Coroutine to increase the Temperature Bar.
    public IEnumerator IncreaseSeconds(float seconds)
    {

        while (elapsedTime < seconds && !stap)
        {
            elapsedTime += Time.deltaTime;
            fillAmount = elapsedTime / seconds;
            CheckInput(fillAmount);
            temp.fillAmount = fillAmount;


            yield return new WaitForEndOfFrame();

        }

        //stops coroutine and sets fillAmount with last known fill
        if (stap)
        {
            temp.fillAmount = fillAmount;
        }

        //looping it in case User failed to click while window was open
        else
        {
            temp.fillAmount = 0;
            stap = false;
            elapsedTime = 0;
            TemperatureRise();
        }
    }


}
