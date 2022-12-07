using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lightMovement : MonoBehaviour
{
    private Vector3 dir = Vector3.left;
    private Vector3 startPos;
    public float offset = 0f; //If yo want to modify the position at the start
    public float speed = 5f;

    // Start is called before the first frame update
    void Start(){
          startPos = transform.position;
          transform.position += Vector3.right * offset;
    }

    // Update is called once per frame
    void Update(){
          transform.Translate(dir*speed*Time.deltaTime);
 
          if(transform.position.x <= startPos.x - 5){
               dir = Vector3.right;
          }
          else if(transform.position.x >= startPos.x + 5){
               dir = Vector3.left;
          }
    }
}
