using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    public GameObject effects;

    public Transform effectsPoint;
    public Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {

            if(LevelManager.instance.respawnPoint != transform.position)
            {
                LevelManager.instance.respawnPoint = transform.position;

                if (effects != null)
                {
                    Instantiate(effects, effectsPoint.position, Quaternion.identity);
                }

                Checkpoint[] allCP = FindObjectsOfType<Checkpoint>();
                

                foreach (Checkpoint cp in allCP) {
                    cp.anim.SetBool("Active",false);
                }

                anim.SetBool("Active", true);
            }
        }
    }
}
