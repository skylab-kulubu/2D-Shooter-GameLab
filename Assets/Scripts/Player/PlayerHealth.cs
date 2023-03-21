using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHealth:MonoBehaviour
{
    [SerializeField] private float playerHealthPoints;
    [SerializeField] private const float maxPlayerHealth = 250;
    [SerializeField] private bool isPlayerDead = false;

    public void PlayerGetDamage(float damage)
    {
        playerHealthPoints = Mathf.Max(playerHealthPoints - damage, 0);
        if (playerHealthPoints == 0)
        {
            PlayerDie();
        }
    }

    public float GetPlayerHealthPoints()
    {
        return playerHealthPoints;
    }

    public void PlayerDie()
    {
        isPlayerDead = true;
        Debug.Log("player dead");
        GetComponent<BoxCollider2D>().enabled = false;
        SceneManager.LoadScene("SampleScene");
    }

    public bool GetIsPlayerDead()
    {
        return isPlayerDead;
    }

    public void AddPlayerHealthPoints(float healthPoints)
    {
        playerHealthPoints += healthPoints;
    }

    public float GetMaxPlayerHealth()
    {
        return maxPlayerHealth;
    }
}
