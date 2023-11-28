using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraFallow : MonoBehaviour

{
    public Transform Target;
    public float speed = 1f;

    void FixedUpdate()

    {
        transform.position = Vector3.Lerp(transform.position, Target.position, speed * Time.fixedDeltaTime );
        transform.rotation = Quaternion.Lerp(transform.rotation, Target.rotation, speed * Time.fixedDeltaTime );
    }

}
