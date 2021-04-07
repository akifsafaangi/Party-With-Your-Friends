using UnityEngine;

public class Interactable : MonoBehaviour
{
    [SerializeField] GameObject customizationPanel;
    void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Player" && Input.GetKeyDown(KeyCode.E))
        {
            customizationPanel.SetActive(true);
            Cursor.visible = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            customizationPanel.SetActive(false);
            Cursor.visible = false;
        }
    }

    public void BackWithButton()
    {
        customizationPanel.SetActive(false);
        Cursor.visible = false;
    }
}
