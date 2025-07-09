using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public static LevelManager instance;
    public float waitBeforeRespawn;
    [HideInInspector]
    public bool respawning;

    private PlayerController player;

    void Awake()
    {
        instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        player = FindObjectOfType<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void Respawn()
    {
        if (!respawning)
        {
            respawning = true;
            StartCoroutine(RespawnCo());
        }
    }

    public IEnumerator RespawnCo()
    {
        yield return new WaitForSecondsRealtime(waitBeforeRespawn);
    }
}
