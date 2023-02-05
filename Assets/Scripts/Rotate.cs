using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotate : MonoBehaviour
{
    [SerializeField] float speedRotateX;
    [SerializeField] float speedRotateY;
    [SerializeField] float speedRotateZ;

    void Update()
    {
        transform.Rotate(360 * speedRotateX * Time.deltaTime, 360 * speedRotateY * Time.deltaTime, 360 * speedRotateZ * Time.deltaTime);
    }
}
