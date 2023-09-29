using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public GameObject follow;
    public Vector2 minCamPos;
    public Vector2 maxCamPos;

    public float smoothTime; //para que la camara sea mas suave
    private Vector2 velocity;
    void Start()
    {
        
    }

    void FixedUpdate()
    {
        float posX = Mathf.SmoothDamp(follow.transform.position.x,
            follow.transform.position.x, ref velocity.x, smoothTime);

        float posY = Mathf.SmoothDamp(follow.transform.position.y,
            follow.transform.position.y, ref velocity.y, smoothTime);

        //clamp de math es para ponerle maximo
        transform.position = new Vector3
            (
                Mathf.Clamp(posX, minCamPos.x, maxCamPos.x),
                Mathf.Clamp(posY,minCamPos.y, maxCamPos.y),
                transform.position.z
            );

        if (follow.transform.position.x > 285)
        {
            maxCamPos.y = 55;

        }
        else 
        {
            maxCamPos.y = 0;
        }
        if (follow.transform.position.x > 403)
        {
            minCamPos.y = 55;
        }
        }
}
