using UnityEngine;
public class TutorialManager : MonoBehaviour
{
    public GameObject tutorialButton; //Tutorial button
    public GameObject[] tutorialPanels; //Array to hold all tutorial panels
    private int currentPanelIndex = 0; //Index to track current panel

    void Start()
    {
        foreach (GameObject panel in tutorialPanels)
        {
            panel.SetActive(false);
        }

        tutorialButton.SetActive(true);
        Time.timeScale = 1;
    }

    public void StartTutorial()
    {
        tutorialButton.SetActive(false);
        tutorialPanels[0].SetActive(true);
        currentPanelIndex = 0;
        PauseGame();
    }

    public void NextPanel()
    {
        if (currentPanelIndex < tutorialPanels.Length - 1)
        {
            tutorialPanels[currentPanelIndex].SetActive(false);
            currentPanelIndex++;
            tutorialPanels[currentPanelIndex].SetActive(true);
        }
    }

    public void EndTutorial()
    {
        tutorialPanels[currentPanelIndex].SetActive(false);
        tutorialButton.SetActive(true);
        ResumeGame();
    }

    private void PauseGame()
    {
        Time.timeScale = 0;
    }

    private void ResumeGame()
    {
        Time.timeScale = 1;
    }
}
