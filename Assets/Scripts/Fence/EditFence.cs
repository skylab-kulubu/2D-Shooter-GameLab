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
            Instantiate(collision.gameObject.GetComponent<FenceUpgradeController>().GetUpgradePanel(), collision.transform.position, Quaternion.identity, GameObject.Find("Canvas").transform);
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Fence"))
        {
            collision.gameObject.GetComponent<FenceUpgradeController>().GetUpgradePanel().SetActive(true);
        }
    }

    public bool GetPanelIsOpen()
    {
        return panelIsOpen;
    }
}
