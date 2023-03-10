using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthDisplay : MonoBehaviour
{
    [SerializeField] private float villageHealthPoints;
    [SerializeField] private float playerHealthPoints;
    [SerializeField] private int currentAmmo;
    [SerializeField] private int magazineCapacity;
    [SerializeField] private float breakTime;

    [SerializeField] Text playerHealthDisplayText;
    [SerializeField] Text villageHealthDisplayText;
    [SerializeField] Text ammoDisplayText;
    [SerializeField] Text breakTimeDisplayText;





    void Update()
    {
        breakTimeDisplayText.text = $"Break Time: {breakTime}"; 

        currentAmmo = GameObject.FindGameObjectWithTag("Player").GetComponent<Shooting>().GetCurrentMagazine().Count;
        magazineCapacity = GameObject.FindGameObjectWithTag("Player").GetComponent<Shooting>().GetCurrentWeapon().GetMagazineCapacity();

        ammoDisplayText.text = $"Ammo: {currentAmmo}/{magazineCapacity}";

        playerHealthPoints = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerHealth>().GetPlayerHealthPoints();
        villageHealthPoints = VillageHealth.villageHealthPoints;
        playerHealthDisplayText.text = "PlayerHealth " + playerHealthPoints.ToString();
        villageHealthDisplayText.text = "VillageHealth " + villageHealthPoints.ToString();
        
        if(FindObjectOfType<SpawnManager>() != null) breakTime = FindObjectOfType<SpawnManager>().GetBreakTime();
    }
}
