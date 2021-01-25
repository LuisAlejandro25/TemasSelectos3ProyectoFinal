using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIPos : MonoBehaviour
{
    public GameObject refPlayer;

    // Update is called once per frame
    void Update()
    {
    	this.transform.LookAt(new Vector3(refPlayer.transform.position.x,this.transform.position.y,refPlayer.transform.position.z));
        this.transform.Rotate(0.0f,180.0f,0.0f,Space.Self);
    }

    public void setUIPos(Transform newPos){
    	Vector3 direction = Vector3.Scale(newPos.forward , new Vector3(1,0,1));
        direction = direction * 0.75f;
        this.transform.position = new Vector3(direction.x + refPlayer.transform.position.x, refPlayer.transform.position.y, direction.z + refPlayer.transform.position.z);
    }
}
