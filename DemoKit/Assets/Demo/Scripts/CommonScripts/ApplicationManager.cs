using UnityEngine;
using System.Collections;

public class ApplicationManager : MonoBehaviour {

    public bool QuitByBackKey = false;

	// Use this for initialization
	void Start () {
	
	}

	
	// Update is called once per frame
	void Update () {

        if (Input.GetKeyUp(KeyCode.Escape) && QuitByBackKey)
        {
			Debug.Log("Eixt Applision");
            Application.Quit();
        }

    }



    private void OnApplicationQuit()
    {
        System.GC.Collect();
    }
}
