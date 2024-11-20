using UnityEngine;
using TMPro;

public class TutorialManager : MonoBehaviour
{
    [System.Serializable]
    public class TutorialStep
    {
        public string tutorialText; // Text to display
        public bool requiresAction; // If true, waits for a specific action
        public string actionName; // The required action (e.g., "Jump", "Shoot")
        public bool isGunJump;
        public bool isKillEnemy;
    }

    public TutorialStep[] tutorialSteps;
    public TextMeshProUGUI tutorialTextBox;

    private int currentStep = 0;
    private bool jumpPerformed = false;
    private float jumpTime = 0f;
    private float allowedActionWindow = 0.5f; // Time frame to perform the action
    public TutorialEnemy tutorialEnemy;

    private void Start()
    {
        tutorialEnemy.gameObject.SetActive(false);
        ShowCurrentStep();
    }

    private void Update()
    {
        var current = tutorialSteps[currentStep];

        if (current.isKillEnemy)
        {
            KillEnemy();
        }
        else if (current.isGunJump)
        {
            GunJump();
        }
        else if (current.requiresAction)
        {
            if (Input.GetButtonDown(current.actionName))
            {
                AdvanceStep();
            }
        }
        else if (Input.GetMouseButtonDown(0))
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
        tutorialTextBox.text = "Tutorial Complete!";
    }

    private void GunJump()
    {
        // Detect jump
        if (Input.GetButtonDown("Jump"))
        {
            jumpPerformed = true;
            jumpTime = Time.time; // Record the time of the jump
        }

        // Detect shoot downward within the time frame
        if (jumpPerformed && Input.GetButtonDown("Fire1"))
        {
            float timeSinceJump = Time.time - jumpTime;
            if (timeSinceJump <= allowedActionWindow && IsShootingDownward())
            {
                AdvanceStep(); // Action complete
            }
        }
    }

    private void KillEnemy()
    {
        tutorialEnemy.gameObject.SetActive(true);

        if (tutorialEnemy.dead)
        {
            AdvanceStep();
        }
    }

    private bool IsShootingDownward()
    {
        // Replace this logic with actual shooting direction detection from your weapon system
        Vector3 aimDirection = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        return aimDirection.y < -0.7f; // Example: Downward threshold
    }
}
