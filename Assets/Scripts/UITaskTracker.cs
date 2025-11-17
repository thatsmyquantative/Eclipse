using UnityEngine;
using UnityEngine.UI;

public class UITaskTracker : MonoBehaviour
{
    public static UITaskTracker Instance;
    
    [Header("UI Elements")]
    public GameObject interactPrompt; // The "E" text
    public Slider progressBar; // The progress bar
    public UnityEngine.UI.Text taskText; // Full path // "Tasks: 1/3" text
    
    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
    }
    
    // Simple methods that we can expand later
    public void ShowInteractPrompt(bool show)
    {
        if (interactPrompt != null)
            interactPrompt.SetActive(show);
    }
    
    public void ShowProgressBar()
    {
        if (progressBar != null)
            progressBar.gameObject.SetActive(true);
    }
    
    public void HideProgressBar()
    {
        if (progressBar != null)
            progressBar.gameObject.SetActive(false);
    }
    
    public void UpdateProgressBar(float progress)
    {
        if (progressBar != null)
            progressBar.value = progress;
    }
    
    public void UpdateTaskProgress(int completed, int total)
    {
        if (taskText != null)
            taskText.text = $"Tasks: {completed}/{total}";
    }
}