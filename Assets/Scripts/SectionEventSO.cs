using UnityEngine;
using System;

public enum SectionState {Start, End }
[CreateAssetMenu(fileName = "SectionEvent", menuName = "Events/Section Event")]
public class SectionEventSO : ScriptableObject
{
    public bool debug;
    
    public event Action<SectionState> OnInvoke; // calls listeners when triggered.

        ///<summary>Trigger the event</summary>
        public void Invoke(SectionState state)
        {
            if (OnInvoke == null)
                return; // no listeners

            OnInvoke(state);
        }
}
