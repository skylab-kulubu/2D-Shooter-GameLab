using UnityEngine.SceneManagement;

public class VillageHealth
{
    public static float villageHealthPoints = 250;

    public void VillageDestroyed()
    {
        SceneManager.LoadScene("SampleScene");
    }
}
