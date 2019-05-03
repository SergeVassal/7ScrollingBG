using UnityEngine;
using System.Collections;

public class StrippedScroller : MonoBehaviour {

	public float scrollSpeed;
	public float tileSizeZ;

	private Vector3 startPosition;
	public Renderer renderer;
	private Vector2 savedOffset;

	void Start ()
	{
		startPosition = transform.position;
		renderer = GetComponent<Renderer> ();
		savedOffset = renderer.sharedMaterial.GetTextureOffset ("_MainTex");
	}

	void Update ()
	{
		float x = Mathf.Repeat (Time.time * scrollSpeed, tileSizeZ*4);
		x = x / tileSizeZ;
		x = Mathf.Floor (x);
		x = x / 4;
        Debug.Log(x);

		Vector2 offset = new Vector2 (x, savedOffset.y);
		renderer.sharedMaterial.SetTextureOffset ("_MainTex", offset);
		float newPosition = Mathf.Repeat (Time.time * scrollSpeed, tileSizeZ);
		transform.position = startPosition + Vector3.back * newPosition;

	}

	void OnDisable(){
		renderer.sharedMaterial.mainTextureOffset =savedOffset;
	}
}
