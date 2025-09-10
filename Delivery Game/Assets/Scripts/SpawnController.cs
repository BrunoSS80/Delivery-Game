using UnityEngine;

public class SpawnController : MonoBehaviour
{
    public GameObject[] slimeSpawn;
    public GameObject[] fanSpawn;

    public void SpawnObjSlime()
    {
        for (int i = 0; i < slimeSpawn.Length; i++)
        {
            if (slimeSpawn[i].activeInHierarchy == false)
            {
                slimeSpawn[i].SetActive(true);
                slimeSpawn[i].transform.position = new Vector2(0, 0);
                break;
            }
        }
    }

    public void SpawnObjFan()
    {
        for (int i = 0; i < fanSpawn.Length; i++)
        {
            if (fanSpawn[i].activeInHierarchy == false)
            {
                fanSpawn[i].SetActive(true);
                fanSpawn[i].transform.position = new Vector2(0, 0);
                break;
            }
        }
    }
}
