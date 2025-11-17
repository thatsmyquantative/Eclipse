using UnityEngine;

public class InteractableTask : MonoBehaviour
{
    [Header("Task Settings")]
    public float interactionDistance = 3f;
    public float interactionTime = 10f;
    
    [Header("Visual Feedback")]
    public Material incompleteMaterial;
    public Material completeMaterial;
    
    private bool isCompleted = false;
    private bool isInteracting = false;
    private float interactionProgress = 0f;
    
    void Start()
    {
        // Set initial material
        GetComponent<Renderer>().material = incompleteMaterial;
    }
    
    void Update()
    {
        // Handle the progress bar filling
        if (isInteracting)
        {
            interactionProgress += Time.deltaTime / interactionTime;
            UITaskTracker.Instance.UpdateProgressBar(interactionProgress);
            
            if (interactionProgress >= 1f)
            {
                CompleteTask();
            }
        }
    }
    
    public void StartInteraction()
    {
        if (!isCompleted)
        {
            isInteracting = true;
            UITaskTracker.Instance.ShowProgressBar();
        }
    }
    
    public void StopInteraction()
    {
        isInteracting = false;
        interactionProgress = 0f;
        UITaskTracker.Instance.HideProgressBar();
    }
    
    void CompleteTask()
    {
        isCompleted = true;
        isInteracting = false;
        
        // Visual feedback
        GetComponent<Renderer>().material = completeMaterial;
        
        // Notify the manager
        TaskManager.Instance.CompleteTask();
        
        // Hide UI
        UITaskTracker.Instance.HideProgressBar();
        
        Debug.Log("Task completed: " + gameObject.name);
    }
    
    public bool CanInteract()
    {
        return !isCompleted;
    }
}