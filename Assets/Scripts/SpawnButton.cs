using UnityEngine;

public class SpawnButton : MonoBehaviour
{
    public GameObject playerPrefab;
    public Transform spawnPoint;

    public void SpawnPlayer()
    {
        if (GameObject.FindWithTag("Player") == null && playerPrefab != null)
        {
            Vector3 position = spawnPoint != null ? spawnPoint.position : Vector3.zero;
            Instantiate(playerPrefab, position, Quaternion.identity);
        }
    }
}