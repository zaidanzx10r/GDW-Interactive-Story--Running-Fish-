using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class CoinRotation : MonoBehaviour
{
    public float RotationSpeed = 50f;
    public float Speed = 2f;
    public float MinY = 2f;
    public float MaxY = 4f;
    void Update()
    {
        float Y = math.lerp(MinY, MaxY,  (math.sin((Time.time * Speed) + 3) + 1) / 2 );
        transform.position = new Vector3(transform.position.x, Y, transform.position.z);
        transform.Rotate(0, 0, RotationSpeed * Time.deltaTime   );
    }
}
