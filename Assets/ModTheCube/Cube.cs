using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cube : MonoBehaviour
{
    public MeshRenderer Renderer;
    Material material;
    public float speed;
    void Start()
    {
        transform.position = new Vector3(3, 4, 1);
        transform.localScale = Vector3.one * 1.3f;
        
        material = Renderer.material;
        StartCoroutine(RandomColor());
        
    }
    
    void Update()
    {
        transform.Rotate(10.0f * Time.deltaTime, 0.0f, 0.0f);
        transform.position += transform.forward * speed * Time.deltaTime;
    }

    public Color ChangeColor()
    {
        return new Color(Random.value,Random.value,Random.value);
    }

    private IEnumerator RandomColor()
    {
        while (true)
        {
            yield return new WaitForSeconds(2);
            material.color = ChangeColor();
        }
    }
}
