using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StrippedJaggedScrollbar : MonoBehaviour 
{
    [SerializeField] private float scrollSpeed;

    private Vector3 startPosition;
    private Renderer renderer;
    private Vector2 savedOffset;
    private float tileSize;    
    private float textureTileAmount = 4f;

    private void Start()
    {
        startPosition = transform.position;
        renderer = GetComponent<Renderer>();
        savedOffset = renderer.sharedMaterial.GetTextureOffset("_MainTex");
        tileSize = transform.localScale.x;
    }

    private void Update()
    {
        float x = Mathf.Repeat(Time.time * scrollSpeed, tileSize*textureTileAmount);
        x = x / tileSize;
        x = Mathf.Floor(x);
        x = x / textureTileAmount;

        Vector2 offset = new Vector2(x, savedOffset.y);
        renderer.sharedMaterial.SetTextureOffset("_MainTex", offset);
        float newPosition = Mathf.Repeat(Time.time * scrollSpeed, tileSize);
        transform.position = startPosition + Vector3.back * newPosition;
    }

    private void OnDisable()
    {
        renderer.sharedMaterial.mainTextureOffset = savedOffset;
    }
}