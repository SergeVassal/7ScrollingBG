using UnityEngine;
using System.Collections;

public class TextureOffsetScroller : MonoBehaviour {

	public float scrollSpeed;
	public Renderer renderer;
	private Vector2 savedOffset;

	// Use this for initialization
	void Start () {
		renderer = GetComponent<Renderer> ();
		savedOffset = renderer.material.GetTextureOffset ("_MainTex");
	
	}
	
	// Update is called once per frame
	void Update () {
		float y = Mathf.Repeat (Time.time * scrollSpeed, 1);
		Vector2 offset=new Vector2(savedOffset.x,y);
		renderer.material.mainTextureOffset =offset;	
	}

	void OnDisable(){
		renderer.material.mainTextureOffset =savedOffset;
	}
}
