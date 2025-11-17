using UnityEngine;
using UnityEngine.UI;
using TMPro; // ← Add this!

public class UITaskTracker : MonoBehaviour
{
    public static UITaskTracker Instance;
    
    [Header("UI Elements")]
    public GameObject interactPrompt; 
    public Slider progressBar;
    public TMP_Text taskText; // ← Change from Text to TMP_Text!
    
    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
    }
    
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