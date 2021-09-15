using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Second_Stage : MonoBehaviour
{
    public static Second_Stage instance;

    Rigidbody rb;

    [HideInInspector] public float height;

    [SerializeField] ParticleSystem burst;

    void Awake()
    {
        instance = this;
    }

    void Update()
    {
        height = transform.position.y;
    }
    public void ApplyInertia(float inertia)
    {        
        if (!rb)
        {
            gameObject.AddComponent<Rigidbody>();
            rb = GetComponent<Rigidbody>();
            rb.useGravity = false;

            rb.AddForce(Vector3.up * Mathf.Abs(inertia), ForceMode.Impulse);
            burst.gameObject.SetActive(true);
            burst.Play();
        }
        
    }
}
