using UnityEngine;

public class GameManager : MonoBehaviour
{
    int activeSectionIndex;
    [SerializeField] TMPro.TextMeshProUGUI instructionsText;
    [SerializeField] TMPro.TextMeshProUGUI errorText;
    [SerializeField] SceneSection[] sections;
    [SerializeField] SceneSection activeSection;
    [SerializeField] int errorCount;

    public int ErrorCount => errorCount;

    public string Hint => activeSection.Hint; // Access from other scripts, gets u the instruction
    public string Instruction => activeSection.Instruction; // Access from other scripts, gets u the instruction

    private void OnEnable()
    {
        Reset();
    }

    public void SetPreviousSection()
    {
        if (activeSectionIndex <= 0)
            return;

        activeSectionIndex -= 1;
        SetupActiveSection(sections[activeSectionIndex]);
    }
    public void SetNextSection()
    {
        Debug.Log("Next Section");
        if (sections.Length <= activeSectionIndex)
        {
            SectionsFinished();
            return;
        }

        activeSectionIndex += 1;
        SetupActiveSection(sections[activeSectionIndex]);
    }

    void SetupActiveSection(SceneSection activeSection)
    {
        Debug.Log("Set Section");
        this.activeSection = activeSection;
        // Sets all Interactable Objects inactive
        foreach (SceneSection section in sections)
            foreach (InteractableObject script in section.ActiveObjects)
                script.SetInteractable(false);
        // Sets the one that should be active in this section as interactable
        foreach (InteractableObject script in this.activeSection.ActiveObjects)
            script.SetInteractable(true);

        instructionsText.text = Instruction;
    }

    public void IncreaseErrorCounter()
    {
        errorCount += 1;
        errorText.text = "Fehler: " + errorCount;
    }
    public void Reset()
    {
        errorCount = 0;
        activeSectionIndex = 0;
        SetupActiveSection(sections[0]);
        errorText.text = "Fehler: 0";
    }

    void SectionsFinished()
    {
        // All Sections are complete, go to main menu or something
    }
}
