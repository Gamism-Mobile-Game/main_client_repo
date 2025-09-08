using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] int maxHp;
    [SerializeField] float speed;
    public void Init()
    {
        GetComponent<EnemyStat>().Init(0,0,maxHp,speed);
    }

    public void Die()
    {
        Debug.Log("Á×À½");
    }
}
