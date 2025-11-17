using UnityEngine;

public class PlayerInteraction : MonoBehaviour
{
    [Header("Interaction Settings")]
    public float interactionRange = 5f;
    public KeyCode interactKey = KeyCode.E;
    
    private Camera playerCamera;
    private InteractableTask currentTask;
    
    void Start()
    {
        playerCamera = GetComponentInChildren<Camera>();
    }
    
    void Update()
    {
        CheckForTask();
        HandleInteractionInput();
    }
    
    void CheckForTask()
    {
        Ray ray = new Ray(playerCamera.transform.position, playerCamera.transform.forward);
        RaycastHit hit;
        
        if (Physics.Raycast(ray, out hit, interactionRange))
        {
            InteractableTask task = hit.collider.GetComponent<InteractableTask>();
            
            if (task != null && task.CanInteract())
            {
                // Found a new task
                if (currentTask != task)
                {
                    currentTask = task;
                    UITaskTracker.Instance.ShowInteractPrompt(true);
                }
            }
            else
            {
                // Not looking at a valid task
                if (currentTask != null)
                {
                    currentTask = null;
                    UITaskTracker.Instance.ShowInteractPrompt(false);
                }
            }
        }
        else
        {
            // Not looking at anything
            if (currentTask != null)
            {
                currentTask = null;
                UITaskTracker.Instance.ShowInteractPrompt(false);
            }
        }
    }
    
    void HandleInteractionInput()
    {
        if (currentTask != null)
        {
            if (Input.GetKeyDown(interactKey))
            {
                currentTask.StartInteraction();
            }
            
            if (Input.GetKeyUp(interactKey))
            {
                currentTask.StopInteraction();
            }
        }
        else
        {
            // If no current task, make sure we're not interacting
            if (Input.GetKeyUp(interactKey))
            {
                // This would stop interaction on any task if player looks away while holding E
                // You might want to track which task is being interacted with more carefully
            }
        }
    }
}
