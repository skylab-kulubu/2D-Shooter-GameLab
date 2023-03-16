using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FenceHealthBar : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float fencehealth = transform.parent.parent.GetComponent<FenceController>().GetFenceHealth();
        float defaulFenceHealth = transform.parent.parent.GetComponent<FenceController>().GetCurrentFence().GetFenceHealthPoints();
        GetComponent<Slider>().value = (fencehealth / defaulFenceHealth);

    }
}
