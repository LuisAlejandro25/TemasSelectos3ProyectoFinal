using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameMaster : MonoBehaviour
{
    //Objects References
	public GameObject camera;
	public GameObject pauseUI;
    public GameObject instructionRef;
    
    //Camera Rotation Var
	private float angleRot;

    //Pause Var
	private bool pauseFlag;
	private bool inputFlag;
    
    //Puzzles Var
    public int numFragments;
	private int count;
    private bool allFragmets;

    //Legendary Reference
    public GameObject legendaryRef;
    public float encounterTime;
    private float countTime;
    private bool startTimer;

    //Audio Controller
    private AudioSource legendarySource;
    public AudioClip dialgaSound;
    public AudioClip patoSound;
    
    // Start is called before the first frame update
    void Start()
    {
        pauseFlag = false;
        inputFlag = false;
        allFragmets = false;
        startTimer = false;
        count = 0;
        legendarySource = this.GetComponent<AudioSource>();
        StartCoroutine("DisplayInstructions");
    }

    // Update is called once per frame
    void Update()
    {
    	if(!pauseFlag){
    		pauseUI.SetActive(false);
            if(startTimer){
                FinishLevel();
            }
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

    public void LegendaryEntry(){
        StartCoroutine("LegendarySpawn");
    }

    IEnumerator LegendarySpawn(){
        legendarySource.Play();
        yield return new WaitForSeconds(3.0f);
        legendarySource.clip = patoSound;
        legendarySource.Play();
        legendaryRef.SetActive(true);
        yield return new WaitForSeconds(2.0f);
        legendarySource.clip = dialgaSound;
        legendarySource.Play();
        startTimer = true;
    }

    IEnumerator DisplayInstructions(){
        instructionRef.SetActive(true);
        yield return new WaitForSeconds(10.0f);
        Destroy(instructionRef.gameObject);
    }

    private void FinishLevel(){
        countTime += Time.deltaTime;
        if(countTime >= encounterTime){
            SceneManager.LoadScene(0);
        }
    }
}
