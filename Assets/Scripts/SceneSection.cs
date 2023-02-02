using UnityEngine;

[System.Serializable]
public class SceneSection
{
    [SerializeField] string sectionName;
    [TextArea][SerializeField] string instruction;
    [TextArea][SerializeField] string hint;
    [SerializeField] InteractableObject[] activeObjects;

    [SerializeField] BoolEventSO[] interactions;
    public BoolEventSO[] Interactions => interactions;

    public InteractableObject[] ActiveObjects => activeObjects;
    public string SectionName => sectionName;
        public string Instruction => instruction;
    public string Hint => hint;
}
