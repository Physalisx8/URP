using UnityEngine;
using System;
using System.Collections;
using Cinemachine;

public class GameManager : MonoBehaviour
{
    [SerializeField] bool debug;
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

    [SerializeField] CinemachineBrain brain;

    [SerializeField] CameraSwitch cameraSwitch;

    public int ErrorCount => errorCount;

    public string Hint => activeSection.Hint; // Access from other scripts, gets u the hint
    public string Instruction => activeSection.Instruction; // Access from other scripts, gets u the instruction
    public string sectionName => activeSection.SectionName;

    //ShowHint  showHint;

    private void OnEnable()
    {
        Reset();
    }

    #region DEMO MODE
    IEnumerator WaitUntilCamIsSet(Action callAfterCamIsSet)
    {
        yield return new WaitForSeconds(brain.m_DefaultBlend.BlendTime);
        callAfterCamIsSet();
    }

    // Called By Button
    public void SkipToPrev()
    {
        if (debug)
            Debug.Log("Skip to PREV");
        // StopAllCoroutines();
        // Wait until Cameras are set, then go to previous section
        StartPreviousSection();
        //StartCoroutine(WaitUntilCamIsSet(StartPreviousSection));
    }
    // Called By Button
    public void SkipToNext()
    {
        if (debug)
            Debug.Log("Skip to NEXT");
        // StopAllCoroutines();
        sections[activeSectionIndex + 1].triggerZone?.OnClick();
        StartNextSection();
    }

    void StartPreviousSection()
    {
        // Start EVENT OF PREVIOUS SECTION
        sections[activeSectionIndex - 1].StateEvent.Invoke(SectionState.Start);
        sections[activeSectionIndex - 1].triggerZone?.OnClick();
        if (debug)
            Debug.Log("Invoke " + sections[activeSectionIndex - 1].StateEvent + " Start");
        SetPreviousSection();
    }

    void StartNextSection()
    {
        // Start EVENT OF CURRENT SECTION
        activeSection.StateEvent.Invoke(SectionState.End);
        activeSection.StateEvent.Invoke(SectionState.Start);
        // Click is simulated so this will set the state
    }
    #endregion

    public void SetPreviousSection()
    {
        if (activeSectionIndex <= 0)
            return;

        activeSectionIndex -= 1;
        SetupActiveSection(sections[activeSectionIndex]);
    }
    public void SetNextSection()
    {
        if (sections.Length <= activeSectionIndex)
        {
            SectionsFinished();
            return;
        }

        showHint.Hide();
        activeSectionIndex += 1;

        SetupActiveSection(sections[activeSectionIndex]);


    }

    void SetupActiveSection(SceneSection activeSection)
    {

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

    private IEnumerator ErrorBig()
    {
        errorText.fontSize = 42;
        yield return new WaitForSeconds(0.5f);
        errorText.fontSize = 36;
    }

    public void IncreaseErrorCounter()
    {
        errorCount += 1;
        errorText.text = "Fehler: " + errorCount;
        errorTextOutro.text = "Fehler: " + errorCount;
        StartCoroutine(ErrorBig());
    }
    public void Reset()
    {
        errorCount = 0;
        activeSectionIndex = 0;
        SetupActiveSection(sections[0]);
        errorText.text = "Fehler: 0";
        errorTextOutro.text = "Fehler: 0";
    }

    public void SectionsFinished()
    {
        GameObject startMenu = GameObject.Find("StartMenu");
        startMenu.GetComponent<StartMenu>().EndDemonstrator();
        // All Sections are complete, go to main menu or something
    }
}
