using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpFenceMaterialController : MonoBehaviour
{
    private int fenceMaterialNumber;
    [SerializeField] private FenceMaterial fenceMaterial;
    private void Start()
    {
        fenceMaterialNumber = fenceMaterial.GetFenceMaterialNumber();
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.gameObject.GetComponent<EditFence>().PickUpMaterial(fenceMaterialNumber);
            Destroy(gameObject);
        }
    }
    public int GetFenceMaterialNumber()
    {
        return fenceMaterialNumber;
    }
}
