using System.Collections;
using UnityEngine;

public class MapController : MonoBehaviour
{
    [SerializeField] Transform player;
    [SerializeField] Transform grid1;
    [SerializeField] Transform grid2;

    private void Start()
    {
        Init();
    }

    public void Init()
    {
        StartCoroutine(MoveGrid());   
    }

    private IEnumerator MoveGrid()
    {
        while (true)
        {
            yield return null;
            if(Mathf.Abs(grid1.position.x - player.position.x) < 0.1f)
            {
                grid2.transform.position = grid1.transform.position + new Vector3(16,0);
            }
            else if (Mathf.Abs(grid2.position.x - player.position.x) < 0.1f)
            {
                grid1.transform.position = grid2.transform.position + new Vector3(16, 0);
            }
        }
    }
}
