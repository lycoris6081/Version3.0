using UnityEngine;
using UnityEngine.UI;

public class PanelController : MonoBehaviour
{
    public GameObject panel; // �bUnity??����?�n���Panel�����??�r�q
    public Button showButton; // �bUnity??����?�D??�ܾާ@����?�����??�r�q

    private bool isPanelVisible = false;

    private void Start()
    {
        // ��l�ƫ�?��??�ƥ�
        showButton.onClick.AddListener(TogglePanelVisibility);
    }

    private void TogglePanelVisibility()
    {
        // ��?Panel���i?��
        isPanelVisible = !isPanelVisible;
        panel.SetActive(isPanelVisible);
    }
}

