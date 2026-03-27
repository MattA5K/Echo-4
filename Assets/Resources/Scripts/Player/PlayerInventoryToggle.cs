using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInventoryToggle : MonoBehaviour
{
    public GameObject inventoryPanel;

    private PlayerInput playerInput;
    private InputAction openInventoryAction;

    public static PlayerInventoryToggle Instance;

    private void Awake()
    {
        Instance = this;

        playerInput = GetComponent<PlayerInput>();

        openInventoryAction = playerInput.actions.FindActionMap("UI").FindAction("OpenInventory");

    }

    private void OnEnable()
    {
        openInventoryAction.Enable();
        openInventoryAction.performed += OnOpenInventoryOpen;
        openInventoryAction.canceled += OnOpenInventoryClose;
    }

    private void OnDisable()
    {
        openInventoryAction.performed -= OnOpenInventoryOpen;
        openInventoryAction.canceled -= OnOpenInventoryClose;
        openInventoryAction.Disable();
    }

    private void OnOpenInventoryOpen(InputAction.CallbackContext context)
    {
        inventoryPanel.SetActive(true);
    }
    private void OnOpenInventoryClose(InputAction.CallbackContext context)
    {
        inventoryPanel.SetActive(false);
        GrabUIManager.Instance.HideGrabPanel();

    }

    public void ShowInventory()
    {
        inventoryPanel.SetActive(true);
    }

    public void HideInventory()
    {
        inventoryPanel.SetActive(false);
    }
}
