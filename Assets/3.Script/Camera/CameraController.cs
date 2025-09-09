using System.Collections;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] Transform cameraPos;
    [SerializeField] float moveSpeed = 1;

    private void Start()
    {
        Init();
    }
    public void Init()
    {
        transform.position = cameraPos.position;
    }

    private void FixedUpdate()
    {
        transform.position = Vector3.Slerp(transform.position, cameraPos.position, Time.deltaTime * moveSpeed);
    }
}
