using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FenceMaterialDisplay : MonoBehaviour
{
    [SerializeField] private Text woodText;
    [SerializeField] private Text rockText;
    [SerializeField] private Text diamondText;

    [SerializeField] private int woodInt;
    [SerializeField] private int rockInt;
    [SerializeField] private int diamondInt;


    void Update()
    {
        woodText.text = "X" + GameObject.FindGameObjectWithTag("Player").GetComponent<EditFence>().GetWoodMaterial().ToString();
        rockText.text = "X" + GameObject.FindGameObjectWithTag("Player").GetComponent<EditFence>().GetRockMaterial().ToString();
        diamondText.text = "X" + GameObject.FindGameObjectWithTag("Player").GetComponent<EditFence>().GetDiamondMaterial().ToString();
    }
}
