using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{

    [SerializeField]
    private float speed = 5.0f;
    private Rigidbody rigidbody;

    public Vector2 margin;//뷰포트 좌표는 (0.0,1.1);

    private void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
    }
    void Update()
    {
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");

        float xSpeed = h * speed;
        float ySpeed = v * speed;

        Vector3 dir  = new Vector3(xSpeed, ySpeed, 0);
        rigidbody.velocity = dir;

        MoveInScreen();

    }

    private void MoveInScreen()
    {
        // Vector3 position = transform.position;
        //
        // position.x = Mathf.Clamp(position.x, -2.5f, 2.5f);
        // position.y = Mathf.Clamp(position.x, -3.5f, 3.5f);
        // transform.position = position;

        Vector3 position = Camera.main.WorldToViewportPoint(transform.position);
        position.x = Mathf.Clamp(position.x, 0.0f + margin.x, 1.0f - margin.x);
        position.y = Mathf.Clamp(position.y, 0.0f + margin.y, 1.0f - margin.y);
        transform.position = Camera.main.ViewportToWorldPoint(position);
        /*
         ScreenPointToRay
         ScreenToViewportPoint
         ScreenToWorldPoint
         ViewportPointToRay
         ViewportToScreenPoint
         ViewportToWorldPoint
         WorldToScreenPoint
         WorldToViewportPoint
         */


        //스크린 좌표: 모니터 해상도 픽셀단위
    }
}
