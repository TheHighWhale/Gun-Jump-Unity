using UnityEngine;
using TMPro;

public class TutorialManager : MonoBehaviour
{
    [System.Serializable]
    public class TutorialStep
    {
        public string tutorialText; // The text to display
        public bool requiresAction; // If true, waits for a specific action
        public string actionName; // The required action (e.g., "Jump", "Shoot")
    }

    public TutorialStep[] tutorialSteps; // Array of tutorial steps
    public TextMeshProUGUI tutorialTextBox; // Reference to the UI text box
    private int currentStep = 0;

    private void Start()
    {
        ShowCurrentStep();
    }

    private void Update()
    {
        if (tutorialSteps[currentStep].requiresAction)
        {
            // Check if the required action is performed
            if (Input.GetButtonDown(tutorialSteps[currentStep].actionName))
            {
                AdvanceStep();
            }
        }
        else if (Input.GetMouseButtonDown(0)) // Left mouse click
        {
            AdvanceStep();
        }
    }

    private void ShowCurrentStep()
    {
        tutorialTextBox.text = tutorialSteps[currentStep].tutorialText;
    }

    private void AdvanceStep()
    {
        currentStep++;
        if (currentStep < tutorialSteps.Length)
        {
            ShowCurrentStep();
        }
        else
        {
            EndTutorial();
        }
    }

    private void EndTutorial()
    {
        tutorialTextBox.text = "Tutorial Complete! Now move out soldier!";
        // Additional logic for ending the tutorial
    }
}
