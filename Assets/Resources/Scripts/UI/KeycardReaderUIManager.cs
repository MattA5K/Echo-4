using TMPro;
using UnityEngine;
using UnityEngine.UIElements;

public class KeycardReaderUIManager : MonoBehaviour
{
    public static KeycardReaderUIManager Instance;
    private KeycardReaderInteraction currentReader;
    private ItemData slotItemData;

    [SerializeField] private GameObject readerPanel;
    [SerializeField] private Image itemIcon;
    [SerializeField] private TMP_Text text;

    private void Awake()
    {
        Instance = this;
    }
    public void ShowReaderPanel(KeycardReaderInteraction reader)
    {
        currentReader = reader;
        readerPanel.SetActive(true);
    }

    public void HideReaderPanel()
    {
        readerPanel.SetActive(false);
    }
}
