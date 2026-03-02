using UnityEngine;

public class ShowInfo : MonoBehaviour
{
    public GameObject infoPanel;

    public void Show()
    {
        if (infoPanel != null) infoPanel.SetActive(true);
    }

    public void Hide()
    {
        if (infoPanel != null) infoPanel.SetActive(false);
    }
}