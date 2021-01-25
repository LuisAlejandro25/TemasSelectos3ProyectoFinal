using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FragmetScript : MonoBehaviour
{
	public GameObject refPlayer;
	public GameObject masterRef;
	public GameObject buttonRef;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
    	ActivateButton();
    	UpdateUIRotation();        
    }

    private void ActivateButton(){
    	Vector3 aux = Vector3.Scale(refPlayer.transform.position , new Vector3(1,0,1));
    	Vector3 aux2 = Vector3.Scale(this.transform.position , new Vector3(1,0,1));

    	Vector3 difference = aux - aux2;
    	float distance = difference.magnitude;
    	if(distance <= 2.0f){
    		buttonRef.SetActive(true);
    	}
    	else{
    		buttonRef.SetActive(false);
    	}
    }

    private void UpdateUIRotation(){
    	buttonRef.transform.LookAt(new Vector3(refPlayer.transform.position.x,this.transform.position.y,refPlayer.transform.position.z));
        buttonRef.transform.Rotate(0.0f,180.0f,0.0f,Space.Self);
    }

    public void fragmentFound(){
    	masterRef.GetComponent<GameMaster>().FindFragment();
    	Destroy(this.gameObject);
    }
}
