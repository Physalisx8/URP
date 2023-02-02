using UnityEngine;

public class GameManager : MonoBehaviour
{
    int activeSectionIndex;
    [SerializeField] TMPro.TextMeshProUGUI instructionsText;
    [SerializeField] TMPro.TextMeshProUGUI errorText;
    [SerializeField] TMPro.TextMeshProUGUI errorTextOutro;
    
    [SerializeField] TMPro.TextMeshProUGUI sectionNameText;
    [SerializeField] SceneSection[] sections;
    [SerializeField] SceneSection activeSection;
    [SerializeField] ShowHint showHint;
    [SerializeField] int errorCount;
    [SerializeField] GameObject startMenu;

    public bool isDemoMode;

    public int ErrorCount => errorCount;

    public string Hint => activeSection.Hint; // Access from other scripts, gets u the hint
    public string Instruction => activeSection.Instruction; // Access from other scripts, gets u the instruction
    public string sectionName => activeSection.SectionName;

    //ShowHint  showHint;

    private void OnEnable()
    {
        Reset();
    }

    public void SetPreviousSection()
    {
        if (activeSectionIndex <= 0)
            return;


        if (isDemoMode){
            foreach (BoolEventSO interaction in activeSection.Interactions)
                interaction.Invoke(false);
        }

        if (isDemoMode){
            foreach (BoolEventSO interaction in sections[activeSectionIndex -1].Interactions)
                interaction.Invoke(true);
        }

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

        if (isDemoMode){
            foreach (BoolEventSO interaction in activeSection.Interactions)
                interaction.Invoke(false);
        }

        showHint.Hide();
        activeSectionIndex += 1;

                if (isDemoMode){
            foreach (BoolEventSO interaction in sections[activeSectionIndex].Interactions)
                interaction.Invoke(true);
        }
 
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
        sectionNameText.text = sectionName;

    }

    public void IncreaseErrorCounter()
    {
        errorCount += 1;
        errorText.text = "Fehler: " + errorCount;
        errorTextOutro.text = "Fehler: "+ errorCount;
    }
    public void Reset()
    {
        errorCount = 0;
        activeSectionIndex = 0;
        SetupActiveSection(sections[0]);
        errorText.text = "Fehler: 0";
        errorTextOutro.text = "Fehler: 0";
    }

    void SectionsFinished()
    {
        Debug.Log("Section Finshed");
        GameObject startMenu = GameObject.Find("StartMenu");
         startMenu.GetComponent<StartMenu>().EndDemonstrator();
        // All Sections are complete, go to main menu or something
    }
}
