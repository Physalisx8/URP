using UnityEngine;

[System.Serializable]
public class SceneSection
{
    [SerializeField] string sectionName;
    [TextArea][SerializeField] string instruction;
    [TextArea][SerializeField] string hint;
    [SerializeField] InteractableObject[] activeObjects;

    public InteractableObject[] ActiveObjects => activeObjects;
    public string SectionName => sectionName;
        public string Instruction => instruction;
    public string Hint => hint;
}
