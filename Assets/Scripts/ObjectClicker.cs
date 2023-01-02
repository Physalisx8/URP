// Checks for Objects with TriggerZone and Triggers then if touched with mouse

using UnityEngine;

public class ObjectClicker : MonoBehaviour
{
    void Update(){
        if (Input.GetKeyDown(KeyCode.Mouse0))
            CheckForTrigger();
    }

    void CheckForTrigger()
    {
        RaycastHit hit;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out hit, 5000))
            if (hit.transform != null)
                if (hit.transform.tag.Equals("ClickableObject"))
                    hit.transform.gameObject.GetComponent<CameraTriggerZone>().OnTriggered();
    }
}
