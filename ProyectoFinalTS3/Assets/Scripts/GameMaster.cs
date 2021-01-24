using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameMaster : MonoBehaviour
{
	public GameObject camera;
	public GameObject pauseUI;
	private float angleRot;
	private bool pauseFlag;
	private bool awa;
	private int state;
    // Start is called before the first frame update
    void Start()
    {
        pauseFlag = false;
        awa = false;
        Debug.Log(pauseFlag);
    }

    // Update is called once per frame
    void Update()
    {
    	if(!pauseFlag){
    		//Debug.Log("Juego");
    		//Time.timeScale = 1f;
    		pauseUI.SetActive(false);
    	}
    	else{
    		//Debug.Log("Pause");
    		//Time.timeScale = 0f;
    		pauseUI.SetActive(true);
    	}

    	angleRot = camera.transform.localRotation.eulerAngles.z;

        if(angleRot > 30.0f && angleRot < 80.0f){
        	if(!awa){
        		pauseFlag = !pauseFlag;
        		awa = true;
        		pauseUI.GetComponent<UIPos>().setUIPos(camera.transform);
        	}
        }
        else{
        	awa = false;
        }
        
    }

    public bool GetPauseFlag(){
    	return pauseFlag;
    }
}
