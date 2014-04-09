namespace CruelWorld.Creatures
{
    public interface ICreature
    {
        bool IsDead { get; }
        bool IsAlive { get; }
        int HitPoints { get; }
        //produce some damage
        int Fight();
        /// <summary>
        /// Take some damage
        /// </summary>
        /// <param name="amount">Total damage dealed amount</param>
        /// <returns>damage recieved amount</returns>
        int Suffer(int amount);
    }
}