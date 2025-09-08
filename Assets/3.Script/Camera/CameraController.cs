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
        StartCoroutine(FollowPlayer());
    }

    private IEnumerator FollowPlayer()
    {
        while (true) 
        {
            yield return null;
            transform.position = Vector3.Slerp(transform.position,cameraPos.position,Time.deltaTime * moveSpeed);
        }
    }
}
