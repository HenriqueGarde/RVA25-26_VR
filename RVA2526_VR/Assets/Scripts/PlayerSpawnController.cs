using UnityEngine;

public class PlayerSpawnController : MonoBehaviour
{
    public Transform xrOrigin;

    public Transform meditationSpawn;
    public Transform stoneSpawn;
    public Transform freeWalkSpawn;

    void Start()
    {
        if (xrOrigin == null)
            return;

        Transform spawnPoint = meditationSpawn;

        switch (GameMode.selectedMode)
        {
            case 1:
                spawnPoint = meditationSpawn;
                break;
            case 2:
                spawnPoint = stoneSpawn;
                break;
            case 3:
                spawnPoint = freeWalkSpawn;
                break;
        }

        CharacterController cc = xrOrigin.GetComponent<CharacterController>();
        if (cc != null) cc.enabled = false;

        xrOrigin.position = spawnPoint.position;

        if (cc != null) cc.enabled = true;
    }
}
