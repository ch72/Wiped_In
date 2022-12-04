using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemyKill : MonoBehaviour
{

    void OnCollisionEnter(Collision col)
    {
        //If player "dies"
        if (col.gameObject.tag == "Player")
        {
            col.gameObject.GetComponent<CharacterControls>().LoadCheckPoint();
            resetEnemyPositions();
		}
	}

    //This is all hard-coded, so if you add enemies, make sure to add it's reset position here on player death
    public static void resetEnemyPositions()
    {
        GameObject.Find("Enemy1").transform.position = new Vector3(0, 0.25f, 8);
        GameObject.Find("Enemy2").transform.position = new Vector3(-15, 0.25f, 30);
    }
}
