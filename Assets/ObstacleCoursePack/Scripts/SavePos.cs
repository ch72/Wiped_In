using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SavePos : MonoBehaviour
{
	public Transform checkPoint;
	public AudioClip[] CheckpointSounds;
	private bool soundTracker = false;

	void OnTriggerEnter(Collider col)
	{
		if (col.gameObject.tag == "Player")
		{
			if(soundTracker == false)
			{
               SoundManager.Instance.RandomSoundEffect(CheckpointSounds);

            }
			soundTracker = true;
			col.gameObject.GetComponent<CharacterControls>().checkPoint = checkPoint.position;
		}
	}
}
