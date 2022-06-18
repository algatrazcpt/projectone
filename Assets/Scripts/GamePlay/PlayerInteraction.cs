using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteraction : MonoBehaviour
{
    public float interactionDistance;
    public TMPro.TextMeshProUGUI interactionText;
    public GameObject interactionHoldGO; // the ui parent to disable when not interacting
    public UnityEngine.UI.Image interactionHoldProgress; // the progress bar for hold interaction type

    Camera cam;
    FpsController playerController;

    [HideInInspector]
    public bool canInteract = true;
    public static PlayerInteraction Instance;

    void Start()
    {
        Instance = this;
        playerController = GetComponent<FpsController>();
        interactionHoldGO.SetActive(false);
        cam = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        if (canInteract)
        {

            Ray ray = cam.ScreenPointToRay(new Vector3(Screen.width / 2f, Screen.height / 2f, 0f));
            RaycastHit hit;

            bool successfulHit = false;

            if (Physics.Raycast(ray, out hit, interactionDistance))
            {
                Interactable interactable = hit.collider.GetComponent<Interactable>();

                if (interactable != null)
                {
                    HandleInteraction(interactable);
                    interactionText.text = interactable.GetDescription();
                    successfulHit = true;

                    interactionHoldGO.SetActive(interactable.interactionType == Interactable.InteractionType.Hold);
                }
            }

            // if we miss, hide the UI
            if (!successfulHit)
            {
                interactionText.text = "";
                interactionHoldGO.SetActive(false);
            }
        }
    }

    void HandleInteraction(Interactable interactable)
    {
        KeyCode key = KeyCode.E;
        switch (interactable.interactionType)
        {
            case Interactable.InteractionType.OpenUIClick:
                // interaction type is click and we clicked the button -> interact
                if (Input.GetKeyDown(key))
                {
                    interactable.Interact();
                    playerController.canMove = false;
                    canInteract = false;
                    // amk texti sıfırlansana debugit later
                    interactionText.text = "";
                    Debug.Log("clickwait");
                }
                break;
            case Interactable.InteractionType.Click:
                // interaction type is click and we clicked the button -> interact
                if (Input.GetKeyDown(key))
                {
                    interactable.Interact();
                }
                break;
            case Interactable.InteractionType.Hold:
                if (Input.GetKey(key))
                {
                    // we are holding the key, increase the timer until we reach 1f
                    interactable.IncreaseHoldTime();
                    if (interactable.GetHoldTime() > 1f)
                    {
                        interactable.Interact();
                        interactable.ResetHoldTime();
                    }
                }
                else
                {
                    interactable.ResetHoldTime();
                }
                interactionHoldProgress.fillAmount = interactable.GetHoldTime();
                break;
            // helpful error for us in the future
            default:
                throw new System.Exception("Unsupported type of interactable.");
        }
    }

    public void StopUIInteraction()
    {
        canInteract = true;
        playerController.canMove = true;
    }

}
