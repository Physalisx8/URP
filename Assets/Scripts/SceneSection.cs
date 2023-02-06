using UnityEngine;
using Cinemachine;

[System.Serializable]
public class SceneSection
{
    [SerializeField] string sectionName;
    [TextArea][SerializeField] string instruction;
    [TextArea][SerializeField] string hint;
    [SerializeField] InteractableObject[] activeObjects;

    [Header("Broadcasting on ...")]
    [SerializeField] SectionEventSO stateEvent;
    public SectionEventSO StateEvent => stateEvent;

    public InteractableObject[] ActiveObjects => activeObjects;

    public CameraTriggerZone triggerZone;
    public string SectionName => sectionName;
        public string Instruction => instruction;
    public string Hint => hint;
}
