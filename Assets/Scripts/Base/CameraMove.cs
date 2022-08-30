using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour
{
	[Header("Global links")]
	public Transform Player;
	[Header("Configuration")]
	[SerializeField] float _smooth = 2;

	private Camera _camera;

    private void Start()
    {
		_camera = GetComponentInChildren<Camera>();

	}

    void LateUpdate() // after all moving for correct work
	{
		Vector3 mouse = Input.mousePosition;//thinks: better get from playerInput
		Vector3 playerPos = _camera.WorldToScreenPoint(Player.position);

		Rect rect = new Rect(playerPos.x - (Screen.width / 2) / 2, playerPos.y - (Screen.height / 2) / 2, Screen.width / 2, Screen.height / 2);

		mouse = Vector2.Max(mouse, rect.min);
		mouse = Vector2.Min(mouse, rect.max);

		Vector3 mousePos = _camera.ScreenToWorldPoint(new Vector3(mouse.x, mouse.y, transform.position.y));
		Vector3 camLook = (Player.position + mousePos) / 2;
		transform.position = Vector3.Lerp(transform.position, new Vector3(camLook.x, Player.position.y, camLook.z), _smooth * Time.deltaTime);
	}
}
