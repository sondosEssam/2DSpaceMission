using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player : MonoBehaviour
{ 

    [SerializeField] private LayerMask FloorLayerMasks;
    private bool jumpkey;
    private Rigidbody2D Rigi;
    private CircleCollider2D circleCollider2d;
    // Start is called before the first frame update
    void Start()
    {
       Rigi = transform.GetComponent<Rigidbody2D>();
       circleCollider2d = transform.GetComponent<CircleCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
         if(isGround() && Input.GetKeyDown(KeyCode.Space)){
            jumpkey = true;
        }
        
        
    }

    void FixedUpdate(){
        if(jumpkey){
            Rigi.velocity= Vector2.up * 10f;
            jumpkey = false;

        }
    }
    private bool isGround(){
     RaycastHit2D raycastHit2d = Physics2D.BoxCast(circleCollider2d.bounds.center,circleCollider2d.bounds.size,0f,Vector2.down, .1f ,FloorLayerMasks);
     Debug.Log(raycastHit2d.collider);
     return raycastHit2d.collider != null;
    }
}
