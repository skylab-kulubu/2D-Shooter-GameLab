using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EditFence : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Fence"))
        {
            Debug.Log(collision.gameObject.name + "yak���ks");
        }
    }
}
