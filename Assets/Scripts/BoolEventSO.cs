using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
[CreateAssetMenu(fileName = "BoolEvent", menuName = "Events/Bool Event")]
public class BoolEventSO : ScriptableObject
{
    public bool debug;
    
    public event Action<bool> OnInvoke; // calls listeners when triggered.

        ///<summary>Trigger the event</summary>
        public void Invoke(bool value)
        {
            if (OnInvoke == null)
                return; // no listeners

            OnInvoke(value);
        }
}
