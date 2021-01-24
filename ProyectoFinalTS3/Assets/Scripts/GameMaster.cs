using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameMaster : MonoBehaviour
{
    //Objects References
	public GameObject camera;
	public GameObject pauseUI;
    
    //Camera Rotation Var
	private float angleRot;

    //Pause Var
	private bool pauseFlag;
	private bool inputFlag;
    
    //Puzzles Var
    public int numFragments;
	public int count;
    public bool allFragmets;
    
    // Start is called before the first frame update
    void Start()
    {
        pauseFlag = false;
        inputFlag = false;
        allFragmets = false;
        count = 0;
    }

    // Update is called once per frame
    void Update()
    {
    	if(!pauseFlag){
    		pauseUI.SetActive(false);
    	}
    	else{
    		pauseUI.SetActive(true);
    	}

    	angleRot = camera.transform.localRotation.eulerAngles.z;

        if(angleRot > 30.0f && angleRot < 80.0f){
        	if(!inputFlag){
        		pauseFlag = !pauseFlag;
        		inputFlag = true;
        		pauseUI.GetComponent<UIPos>().setUIPos(camera.transform);
        	}
        }
        else{
        	inputFlag = false;
        }
        
    }

    public bool GetPauseFlag(){
    	return pauseFlag;
    }

    public void FindFragment(){
        if(count < numFragments){
            count++;
            if(count == numFragments){
                allFragmets = true;
            }
        } 
    }

    public bool GetFragmentsBool(){
        return allFragmets;
    }
}
