using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PingPongMovement : MonoBehaviour {

    public Vector3 pointB;
    public float travelTime;
    public float flipValue;  

    IEnumerator Start()
    {
        var pointA = transform.position;
        while (true)
        {
            yield return StartCoroutine(MoveObject(transform, pointA, pointB, travelTime));
            yield return StartCoroutine(MoveObject(transform, pointB, pointA, travelTime));
        }
    }

    IEnumerator MoveObject(Transform thisTransform, Vector3 startPos, Vector3 endPos, float time)
    {
        var i = 0.0f;
        var rate = 1.0f / time;
        while (i < 1.0f)
        {
            i += Time.deltaTime * rate;
            thisTransform.position = Vector3.Lerp(startPos, endPos, i);
            yield return null;
        }

        //This is the code to flip the sprite on the X-axis when the destination has been reached
        Vector3 theScale = thisTransform.localScale;
        theScale.x *= -1;
        thisTransform.localScale = theScale;
        
    }
}
