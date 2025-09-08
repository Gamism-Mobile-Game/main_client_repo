public interface IGetDamage
{
    public int Hp {  get; set; }
    public int MaxHp {  get; set; }

    public void GetDamage(int damage) 
    {
        Hp -= damage;
    }
}