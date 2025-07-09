using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillPlayer : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            //other.gameObject.GetComponent<CharacterController>().Move(Vector3.up - other.transform.position); (Just a simple example of respawning)

            LevelManager.instance.Respawn();
        }
    }
}
