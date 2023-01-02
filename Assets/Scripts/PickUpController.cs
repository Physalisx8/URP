using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpController : MonoBehaviour
{
    public Transform player, tongsContainer;
    Ray ray;
    RaycastHit hit;

    public float pickUpRange;

    public bool equipped;

    // Anfangsposition der Zange
    private Vector3 initialPos;
    private Quaternion initalRot;

    private void Start()
    {
        // initiale Position speichern
        initialPos = transform.localPosition;
        initalRot = transform.localRotation;
    }

    private void Update()
    {
        Vector3 distanceToPlayer = player.position - transform.position;

        //Zange zurück legen, wenn space gedrückt wird
        if (equipped && Input.GetKeyDown(KeyCode.Space)) Drop();

        //Raycast wenn geklickt wird
        if(Input.GetMouseButtonDown(0)) {
            ray = Camera.main.ScreenPointToRay(Input.mousePosition);
         if(Physics.Raycast (ray, out hit))
         {
            //hier würde ich eigentlich gerne nach dem namen "tongs" suchen, allerdings kommt er nicht durch den Trigger inv_Cube_Tongs (warum auch immer)
            //wäre schöner raus zu finden wie man den deaktivieren kann/machen kann, dass er den Ray durchlässt

            //wenn das GameObject getroffen wird und die Zange nicht equipped ist und Player nah genug dran (kann also nicht vom start bedient werden)
            if(hit.transform.gameObject.name == "inv_Cube_Tongs" && !equipped && distanceToPlayer.magnitude <= pickUpRange) {
                PickUp();
             }
         }
        }
    }

    private void PickUp()
    {
        equipped = true;

        //Tongs wird ein Kind von dem Container und wir setzen ihn an die richtige Stelle
        transform.SetParent(tongsContainer);
        transform.localPosition = Vector3.zero;
        transform.localRotation = Quaternion.Euler(Vector3.zero);
        transform.localScale = Vector3.one;
    }

    private void Drop()
    {
        equipped = false;

        //Wieder vom tongsContainer entfernen
        transform.SetParent(null);

        //An die Ausgangsposition setzen
        transform.localPosition = initialPos;
        transform.localRotation = initalRot;
    }
}

