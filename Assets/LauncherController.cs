using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LauncherController : MonoBehaviour
{
    
    public Collider bola;
    public KeyCode input;
    public float maxTimeHold;
    public float maxForce;
    private bool isHold = false;
     private void OnCollisionStay(Collision collision) {
        if(collision.collider ==bola){
            ReadInput(bola);
        }
    }

    private void ReadInput(Collider collider){

        if (Input.GetKey(input) && !isHold){
            StartCoroutine(startHold(collider));
        }
    }
    private IEnumerator startHold(Collider collider){
        isHold = true;
        float force = 0.0f;
        float timehold = 0.0f;
        while(Input.GetKey(input)){
            force = Mathf.Lerp(0, maxForce, timehold/maxTimeHold);
            yield return new WaitForEndOfFrame();
            timehold += Time.deltaTime;
        }
        collider.GetComponent<Rigidbody>().AddForce(Vector3.forward*force);
        isHold = false;

    }
}
