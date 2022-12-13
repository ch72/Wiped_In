using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Finished : MonoBehaviour
{
    public AudioClip[] CelebrationSounds;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    IEnumerator OnTriggerEnter(Collider col)
	{
		if (col.gameObject.tag == "Player")
		{
            SoundManager.Instance.RandomSoundEffect(CelebrationSounds);
            Stopwatch.StopStopwatch();
            yield return new WaitForSeconds(5);
            UnityEngine.SceneManagement.SceneManager.LoadScene("StartScene");
		}
	}
}

