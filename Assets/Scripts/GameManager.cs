using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private VillageHealth villageHealth;
    [SerializeField] private PlayerHealth playerHealth;

    void Update()
    {
        if(VillageHealth.villageHealthPoints <= 0)
        {
            villageHealth.VillageDestroyed();
        }
        
    }
}
