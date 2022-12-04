using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemyKill : MonoBehaviour
{

    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.tag == "Player")
        {
			col.gameObject.GetComponent<CharacterControls>().LoadCheckPoint();
            transform.position = new Vector3(0, 0.25f, 8);
		}
	}
}
