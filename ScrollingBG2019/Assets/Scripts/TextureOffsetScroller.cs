using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextureOffsetScroller : MonoBehaviour 
{
    [SerializeField] private float scrollSpeed;

    private Renderer renderer;
    private Vector2 savedOffset;



    private void Start()
    {
        renderer = GetComponent<Renderer>();
        savedOffset = renderer.material.GetTextureOffset("_MainTex");
    }

    private void Update()
    {
        float y = Mathf.Repeat(Time.time * scrollSpeed, 1);
        Vector2 offset = new Vector2(savedOffset.x, y);
        renderer.material.mainTextureOffset = offset;
    }

    private void OnDisable()
    {
        renderer.material.mainTextureOffset = savedOffset;
    }
}
