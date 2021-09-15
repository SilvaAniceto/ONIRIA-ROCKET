using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parachute : MonoBehaviour
{
    MeshRenderer mRenderer;
    MeshCollider mCollider;

    Rigidbody rb;

    GameObject firstStage;

    public float timer = 1.5f;

    bool wind = false;

    // Start is called before the first frame update
    void Awake()
    {
        mRenderer = GetComponent<MeshRenderer>();
        mCollider = GetComponent<MeshCollider>();

        firstStage = GameObject.Find("PrimeiroEstagio");
    }

    private void Update()
    {
        if (wind)
            rb.AddForce(Vector2.right * 0.1f, ForceMode.Force);
    }


    // Update is called once per frame
    public void ParachuteSequence()
    {        
        firstStage.transform.SetParent(this.transform);

        if (!rb)
        {
            gameObject.AddComponent<Rigidbody>();
            
            rb = GetComponent<Rigidbody>();

            wind = true;
        }
        else
        {
            return;
        }

        Invoke("OpenParachute", 10f);
    }

    void OpenParachute()
    {
        mRenderer.enabled = true;
        mCollider.enabled = true;
        rb.drag = 1.4f;
    }
}
