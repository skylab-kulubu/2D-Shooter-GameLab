using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHealthBar : MonoBehaviour
{
    
    void Update()
    {
        float healthPoints = transform.parent.parent.GetComponent<EnemyStateManager>().currentHealthPoints;
        float defaultHealthPoints = transform.parent.parent.GetComponent<EnemyStateManager>().enemyStats.GetHealthPoints();
        GetComponent<Slider>().value = healthPoints / defaultHealthPoints;

        if(healthPoints <= 0)
        {
            Destroy(gameObject);
        }
    }
}
