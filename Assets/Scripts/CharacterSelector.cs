using UnityEngine;

public class CharacterSelector : MonoBehaviour
{
    [Header("Character References")]
    public GameObject playerCharlie;
    public GameObject playerJorge;

    void Start()
    {
        if (playerCharlie != null) playerCharlie.SetActive(false);
        if (playerJorge != null) playerJorge.SetActive(false);
    }

    public void SelectCharlie()
    {
        if (playerCharlie != null)
        {
            playerCharlie.SetActive(true);
        }
        if (playerJorge != null)
        {
            playerJorge.SetActive(false);
        }
    }

    public void SelectJorge()
    {
        if (playerJorge != null)
        {
            playerJorge.SetActive(true);
        }
        if (playerCharlie != null)
        {
            playerCharlie.SetActive(false);
        }
    }
}