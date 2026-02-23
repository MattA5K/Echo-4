using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInventoryToggle : MonoBehaviour
{
    [SerializeField] private GameObject inventoryPanel;

    private PlayerInput playerInput;
    private InputAction openInventoryAction;

    private void Awake()
    {
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
        openInventoryAction.canceled += OnOpenInventoryClose;
        openInventoryAction.Disable();
    }

    private void OnOpenInventoryOpen(InputAction.CallbackContext context)
    {
        inventoryPanel.SetActive(true);
    }
    private void OnOpenInventoryClose (InputAction.CallbackContext context)
    {
        inventoryPanel.SetActive(false);
    }
}
