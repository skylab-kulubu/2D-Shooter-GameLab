using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthDisplay : MonoBehaviour
{
    [SerializeField] private float villageHealthPoints;
    [SerializeField] private float playerHealthPoints;
    [SerializeField] Text playerHealthDisplayText;
    [SerializeField] Text villageHealthDisplayText;


    void Update()
    {
        playerHealthPoints = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerHealth>().GetPlayerHealthPoints();
        villageHealthPoints = VillageHealth.villageHealthPoints;
        playerHealthDisplayText.text = "PlayerHealth " + playerHealthPoints.ToString();
        villageHealthDisplayText.text = "VillageHealth " + villageHealthPoints.ToString();
    }
}
