using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Brick : MonoBehaviour
{
    public int hits = 1;
    public int score = 100;
    public Vector3 rotationVector;
    public Material highlightMaterial;

    private Renderer render;
    private Material originalMaterial;

    void Start()
    {
        render = GetComponent<Renderer>();
        originalMaterial = render.sharedMaterial;
        transform.Rotate(rotationVector * Random.Range(0, 10));
    }

    void Update()
    {
        transform.Rotate(rotationVector * Time.deltaTime);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (isLastHit())
        {
            Destroy(gameObject);
        }
        else
        {
            highlightBrick();
        }
    }

    private bool isLastHit()
    {
        hits--;
        return hits <= 0;
    }

    private void highlightBrick()
    {
        render.sharedMaterial = highlightMaterial;
        Invoke("resetMaterial", 0.05f);
    }

    private void resetMaterial()
    {
        render.sharedMaterial = originalMaterial;
    }
}
