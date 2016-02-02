using UnityEngine;
using System.Collections;

public class PlayerControls : MonoBehaviour 
{
	private float _jumpForce = 180f;

	private bool _inAir = true;
	private bool _grounded;

	private Vector2 _screenMidPoint;
	private Vector2 _mouseposition;

	//private Vector2 groundTarget = new Vector2(0, -0.2f);

	private Rigidbody2D _rigid2D;
	//private float _maxRayDepth = 0f;

	void Awake()
	{
		_rigid2D = GetComponent<Rigidbody2D>();

		_screenMidPoint = Camera.main.ScreenToViewportPoint( new Vector2( Screen.width / 2f, Screen.height / 2f ) );
		_mouseposition = Camera.main.ScreenToViewportPoint( new Vector2( Input.mousePosition.x, Input.mousePosition.y ) );
	}

	void Update()
	{
		//CheckGrounded();
		Jumps();
	}

	private void Jumps()
	{
		if(Input.GetButtonDown("Jump") && _grounded && !_inAir || Input.GetMouseButtonDown(0) && _grounded && !_inAir && _mouseposition.x < _screenMidPoint.x)
		{
			_rigid2D.AddForce(new Vector2(0, _jumpForce));
			_inAir = true;
		}
		else if(Input.GetButtonDown("Jump") && _inAir && !_grounded || Input.GetMouseButtonDown(0) && !_grounded && _inAir && _mouseposition.x < _screenMidPoint.x)
		{
			_rigid2D.AddForce(new Vector2(0, _jumpForce));
			_inAir = false;
		}
	}

	#region Collision Checks

	private void OnCollisionEnter2D(Collision2D c)
	{
		if(c.gameObject.tag == Tags.GROUNDTAG)
		{
			_grounded = true;
			_inAir = false;
		}
		else if(c.gameObject.tag == null)
		{
			_grounded = false;
			_inAir = true;
		}
	}

	private void OnCollisionExit2D(Collision2D c)
	{
		if(c.gameObject.tag == Tags.GROUNDTAG)
		{
			_grounded = false;
			_inAir = true;
		}
	}

	#endregion

/*
	private void CheckGrounded ()
	{
		RaycastHit2D hit = Physics2D.Raycast(transform.position, -Vector2.down, _maxRayDepth, groundLayer);

		if(hit != null)
		{
			_grounded = true;
			Debug.DrawRay(transform.position, groundTarget, Color.green);
		}
		else
		{
			_grounded = false;
			Debug.DrawRay(transform.position, groundTarget, Color.red);
		}

		Debug.Log("On Ground: " + _grounded + " In Air: " + _inAir);
	}
*/

}