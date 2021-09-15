using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rocket_Script : MonoBehaviour
{
    public static Rocket_Script instance;

    Rigidbody rb;

    [HideInInspector] public float fuelTime;
    [SerializeField] float thrustForce;

    [HideInInspector] public float maxHeight;
    float inertia;

    GameObject secondStage;
    GameObject firstStage;
    GameObject parachute;

    AudioSource audioSource;

    [HideInInspector] public bool start;
    void Awake()
    {
        audioSource = GetComponentInChildren<AudioSource>();  
    }

    private void Start()
    {
        instance = this;

        start = false;

        rb = GetComponent<Rigidbody>();
        fuelTime = 5.0f;

        secondStage = GameObject.Find("Corpo_Nariz");
        firstStage = GameObject.Find("PrimeiroEstagio");
        parachute = GameObject.Find("Paraquedas");

        audioSource.volume = 0;
    }
    void FixedUpdate()
    {
        if (start)
        {
            fuelTime -= Time.fixedDeltaTime;
            audioSource.volume = 1;
            if (fuelTime <= 0)
            {
                fuelTime = 0;
                inertia = rb.velocity.y;
                audioSource.Stop();
                if (rb.velocity.y < 0)
                {
                    Deploy();  
                    GetMaxHeight();
                }
            }
            else
            {                
                rb.AddForce(Vector3.up * thrustForce, ForceMode.Acceleration);
                return;
            }
        }

        rb.AddForce(Vector3.right * 0.2f, ForceMode.Force);
    }
    void Deploy()
    {
        firstStage.transform.SetParent(null);
        
        parachute.transform.SetParent(null);
        parachute.GetComponent<Parachute>().ParachuteSequence();

        secondStage.transform.SetParent(null);
        secondStage.GetComponent<Second_Stage>().ApplyInertia(inertia);
    }

    void GetMaxHeight()
    {
        maxHeight = secondStage.transform.position.y;

        Destroy(gameObject);
    }
}
