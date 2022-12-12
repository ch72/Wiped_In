﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class KillZone : MonoBehaviour
{
    public AudioClip[] PlayerDeaths;
    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "Player")
        {
			col.gameObject.GetComponent<CharacterControls>().LoadCheckPoint();
            EnemyKill.resetEnemyPositions();
            SoundManager.Instance.RandomSoundEffect(PlayerDeaths);
		}
	}
}
