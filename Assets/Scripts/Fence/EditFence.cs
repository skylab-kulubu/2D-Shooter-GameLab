using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EditFence : MonoBehaviour
{
    private bool panelIsOpen = false;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Fence"))
        {
            collision.gameObject.GetComponent<FenceUpgradeController>().GetCurrentUpgradePanel().SetActive(true);
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Fence"))
        {
            collision.gameObject.GetComponent<FenceUpgradeController>().GetCurrentUpgradePanel().SetActive(false);
        }
    }

    public bool GetPanelIsOpen()
    {
        return panelIsOpen;
    }
}
