using UnityEngine;

[System.Serializable]
public class SceneSection
{
    [SerializeField] string sectionName = "new Section";
    [TextArea][SerializeField] string instruction;
    [TextArea][SerializeField] string hint;
    [SerializeField] InteractableObject[] activeObjects;

    public InteractableObject[] ActiveObjects => activeObjects;
    public string Instruction => instruction;
    public string Hint => hint;
}
