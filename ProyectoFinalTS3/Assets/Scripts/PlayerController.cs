using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
	public float speed = 1.5f;
	private CharacterController ccPlayer;
	public GameObject camera;
	private float angleRot;
    public GameObject masterRef;
    private float gravity = 5f;
    // Start is called before the first frame update
    void Start()
    {
        ccPlayer = this.GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        if(!masterRef.GetComponent<GameMaster>().GetPauseFlag()){
            angleRot = camera.transform.localRotation.eulerAngles.x;

            Vector3 move = Vector3.Scale(camera.transform.forward , new Vector3(1,0,1));
            move.y -= gravity;
            if(Input.GetMouseButton(0)){
                if((angleRot > 0.0f && angleRot < 30.0f) || (angleRot > 330.0f && angleRot < 360.0f)){
                    ccPlayer.Move(move * Time.deltaTime * speed);
                }
            }            
        }
    	
    }
}
