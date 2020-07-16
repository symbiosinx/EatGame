using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class DeathPanel : MonoBehaviour
{
    
	[SerializeField] GameObject deathPanel;

    void Start()
    {
		GlobalEventHandler.instance.OnPlayerDeath += () => {
			Time.timeScale = 0.01f;
			deathPanel.SetActive(true);
		};
    }

	public void ExitToMain() {
		Time.timeScale = 1f;
		SceneManager.LoadScene(0);
	}

    void Update()
    {
        
    }
}
