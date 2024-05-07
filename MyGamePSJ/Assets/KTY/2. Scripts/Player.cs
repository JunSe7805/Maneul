using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
	public bool isGrounded;  //sh! ������ public �̶� private �� �ٲ���
	public bool isSprinting;

	private Transform cam;

	public float walkSpeed = 3f; // �̵� �ӵ�
	public float sprintSpeed = 6f; // �޸��� �ӵ�
	public float jumpForce = 5f; // ���� ��
	public float gravity = -9.8f; // �߷�

	public float playerWidth = 0.15f; // �÷��̾� �ʺ�?
	public float boundsTolerance = 0.1f; // �ٿ ��� ����?

	private float horizontal;
	private float vertical;
	private float mouseHorizontal;
	private float mouseVertical;
	public float mouseRate=10.0f;
	private Vector3 velocity; // ��ü �ӵ�

	private float verticalMomemtum = 0; // ���� ���?
	private bool jumpRequest;

	//private PhotonView pv;
	//private CinemachineVirtualCamera virtualCamera;

	//private new Transform transform;

	private void Awake()
	{
		cam = GameObject.Find("Main Camera").transform;
	}
    //void Start()
    //{
    //    transform = GetComponent<Transform>();
    //    pv = GetComponent<PhotonView>();
    //    virtualCamera = GameObject.FindObjectOfType<CinemachineVirtualCamera>();

    //     �ڽ��� ĳ������ ��� �ó׸ӽ� ī�޶� ����
    //    if (pv.isMine)
    //    {
    //        virtualCamera.Follow = transform;
    //        virtualCamera.LookAt = transform;

    //    }
    //}

    private void Update()
	{
		GetPlayerInputs();
	}

	private void FixedUpdate()
	{
		CalculateVelocity();

		if (jumpRequest)
			Jump();

		transform.Rotate(Vector3.up * mouseHorizontal* mouseRate); // ���콺 ���� �̵� �� y�� ȸ��
		cam.Rotate(Vector3.right * -mouseVertical*mouseRate);

		// Space.~: �̵��� ������ ���� ������ ��Ÿ���� ������
		// Space.World: �ش� ������Ʈ�� �ӵ�(velocity)�� ���⿡ ���� ���� �������� �̵�
		// Space.Self: �ش� ������Ʈ�� ���� ���������� ����� �ӵ��� ���� �̵�
		transform.Translate(velocity, Space.World);
	}

	void Jump()
	{
		verticalMomemtum = jumpForce; // ���� ����� ���� ���� ����.
		isGrounded = false;
		jumpRequest = false;
	}

	private void CalculateVelocity()
	{
		//// �÷��̾��� �Է¿� ���� ���Ĺ� �� �¿� ���������� �̵��ӵ��� ���.
		//velocity = ((transform.forward * vertical) + (transform.right * horizontal)) * Time.deltaTime * 3f;
		//velocity += Vector3.up * gravity * Time.deltaTime;

		//velocity.y = CheckDownSpeed(velocity.y);


		// Affect vertical momentum with gravity
		// �߷��� ���� ����� �ִ� ���� (���� �� �� ���ӵǰ� ������ �� ���ӵǴ� ȿ��?)
		if (verticalMomemtum > gravity)
			verticalMomemtum += Time.fixedDeltaTime * gravity; // Time.fixedDeltaTime : ������ ��ŸŸ��

		if (isSprinting)
			velocity = ((transform.forward * vertical) + (transform.right * horizontal)) * Time.fixedDeltaTime * sprintSpeed;
		else
			velocity = ((transform.forward * vertical) + (transform.right * horizontal)) * Time.fixedDeltaTime * walkSpeed;

		// ���� ��� ����
		velocity += Vector3.up * verticalMomemtum * Time.fixedDeltaTime;
    }

	// �÷��̾� �Է�
	private void GetPlayerInputs()
	{
		horizontal = Input.GetAxis("Horizontal");	// Ű���� ���� �̵�
		vertical = Input.GetAxis("Vertical");		// Ű���� ���� �̵�
		mouseHorizontal = Input.GetAxis("Mouse X"); // ���콺 ���� �̵�
		mouseVertical = Input.GetAxis("Mouse Y");   // ���콺 ���� �̵�

		if (Input.GetButtonDown("Sprint"))
			isSprinting = true;
		if (Input.GetButtonUp("Sprint"))
			isSprinting = false;

		if (isGrounded && Input.GetButtonDown("Jump"))
			jumpRequest = true;
	}

}
