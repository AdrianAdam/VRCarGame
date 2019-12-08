using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GUIManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

	public void loadLevel1()
	{
		SceneManager.LoadScene("Level1");
	}

	public void loadLevel2()
	{
		SceneManager.LoadScene("Level2");
	}

	public void loadLevel3()
	{
		SceneManager.LoadScene("Level3");
	}

	public void loadLevel4()
	{
		SceneManager.LoadScene("Level4");
	}

	public void loadLevel5()
	{
		SceneManager.LoadScene("Level5");
	}

	public void loadLevel6()
	{
		SceneManager.LoadScene("Level6");
	}

	public void loadLevel7()
	{
		SceneManager.LoadScene("Level7");
	}

	public void loadLevel8()
	{
		SceneManager.LoadScene("Level8");
	}

	public void loadLevel9()
	{
		SceneManager.LoadScene("Level9");
	}

	public void quitGame()
	{
		Application.Quit();
	}
}
