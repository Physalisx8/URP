// Checks for Objects with TriggerZone and Triggers then if touched with mouse

using UnityEngine;
using System.Collections;

public class ObjectClicker : MonoBehaviour
{
    GameObject activeObj;

void OnEnable(){
    StartCoroutine(CheckForHover());
}

void OnDisable(){
    StopAllCoroutines();
}
    void Update(){
        if (Input.GetKeyDown(KeyCode.Mouse0))
            CheckForClick();

    }

    void CheckForClick()
    {
        RaycastHit hit;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out hit, 5000))
            if (hit.transform != null)
                if (hit.transform.tag.Equals("ClickableObject"))
                    hit.transform.gameObject.GetComponent<InteractableObject>().OnClick();
    }

// Scans for hovering object every 0.1 second. We could do it in Update also, but this saves a bit of ressources
    IEnumerator CheckForHover(){
        while (true){
            RaycastHit hit;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        GameObject currentObj = null;
        if (Physics.Raycast(ray, out hit, 5000))
            if (hit.transform != null)
                if (hit.transform.tag.Equals("ClickableObject")){
                    InteractableObject script = hit.transform.gameObject.GetComponent<InteractableObject>();
                    if (script != null){
                        script.OnHover(true);
                        currentObj = hit.transform.gameObject;
                    }
                }

        //When the active object isnt hovered over anymore, fire the onhover false thingy.
            if (currentObj != activeObj){
                if (activeObj != null)
                    activeObj.GetComponent<InteractableObject>().OnHover(false);
                
                activeObj = currentObj;
            }



        yield return new WaitForSeconds(0.1f);
        }
    }
}
