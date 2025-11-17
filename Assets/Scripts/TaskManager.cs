using UnityEngine;
using UnityEngine.SceneManagement;

public class TaskManager : MonoBehaviour
{
    public static TaskManager Instance;
    
    [Header("Task Settings")]
    public int totalTasks = 3;
    public int completedTasks = 0;
    
    [Header("UI References")]
    public GameObject dayCompletePanel;
    public UnityEngine.UI.Text dayCompleteText;
    
    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
    
    public void CompleteTask()
    {
        completedTasks++;
        
        // Update UI
        UITaskTracker.Instance.UpdateTaskProgress(completedTasks, totalTasks);
        
        // Check if all tasks are done
        if (completedTasks >= totalTasks)
        {
            StartDayCompleteSequence();
        }
    }
    
    void StartDayCompleteSequence()
    {
        Debug.Log("All tasks completed! Day finished.");
        
        // Show "Day 1 Completed" text
        if (dayCompletePanel != null)
        {
            dayCompletePanel.SetActive(true);
            dayCompleteText.text = "Day 1 Completed";
        }
        
        // Start fade to black and load next scene after delay
        Invoke("LoadNextDay", 3f); // Show message for 3 seconds
    }
    
    void LoadNextDay()
    {
        // Add fade effect here later
        SceneManager.LoadScene("Day2Scene"); // Create this scene in Build Settings
    }
}