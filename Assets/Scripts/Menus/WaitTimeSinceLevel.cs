using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WaitTimeSinceLevel : MonoBehaviour {

	void Update () {

        if (Time.timeSinceLevelLoad >= 5f)
        {
            SceneManager.LoadScene("MainMenu");
        }
		
	}
}
