using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Von InteractableObject erben lassen
public class Knife : InteractableObject

/*
550 Dunkelbraun #352201
630 Braunrot #542803
680 Dunkelrot #681100
740 Dunkelkirschrot #861600
780 Kirschrot #a00000
810 Hellkirschrot #c11b1b
850 Hellrot #d44115
900 Gut Hellrot #e9582c
950 Gelbrot #e97e1c
1000 Hellgelbrot #ffaa0f
1100 Gelb #fbc034
1200 Hellgelb #ffcf61
>1300 Gelbweiß #ffe6ad
*/

{
    GameManager gameManager;
    //inFurnace muss gesetzt werden, wenn das Messer in der Esse ist und ide Tür geschlossen wurde. KP wie wir das realisieren. Wird schon irgendwie xD

    void Awake(){
        gameManager = FindObjectOfType<GameManager>();
    }
    public override void OnClick()
    {
        base.OnClick(); // Immer den BUms hier ausführen

        // Your code what happens on a click
       /* 
         if (gameManager != null)
        {
            if (!isInteractable){
                gameManager.IncreaseErrorCounter();
            }
            else{
                gameManager.SetNextSection();
            }
        } else {
            Debug.Log("gameManager = null");
        }
        */
        
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
}
