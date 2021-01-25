using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivateLegendary : MonoBehaviour
{
	public GameObject refPlayer;
	public GameObject masterRef;
	public GameObject canvasRef;
	public GameObject completeRef;
	public GameObject missingRef;
	public GameObject buttonRef;
	public GameObject diamondRef;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        ActivateCanvas();
        UpdateUIRotation();
    }

    private void ActivateCanvas(){
    	Vector3 aux = Vector3.Scale(refPlayer.transform.position , new Vector3(1,0,1));
    	Vector3 aux2 = Vector3.Scale(this.transform.position , new Vector3(1,0,1));

    	Vector3 difference = aux - aux2;
    	float distance = difference.magnitude;
    	if(canvasRef != null){
    		if(distance <= 3.0f){
	    		canvasRef.SetActive(true);
	    		if(masterRef.GetComponent<GameMaster>().GetFragmentsBool()){
	    			missingRef.SetActive(false);
	    			completeRef.SetActive(true);
	    			buttonRef.SetActive(true);
	    		}
	    		else{
	    			buttonRef.SetActive(false);
	    			completeRef.SetActive(false);
	    			missingRef.SetActive(true);
	    		}
	    	}
	    	else{
	    		canvasRef.SetActive(false);
	    	}
    	}
    }

    private void UpdateUIRotation(){
    	canvasRef.transform.LookAt(new Vector3(refPlayer.transform.position.x,canvasRef.transform.position.y,refPlayer.transform.position.z));
        canvasRef.transform.Rotate(0.0f,180.0f,0.0f,Space.Self);
    }

    public void StartEncounter(){
    	diamondRef.SetActive(true);
    	masterRef.GetComponent<GameMaster>().LegendaryEntry();
    	Destroy(canvasRef.gameObject);
    }
}
