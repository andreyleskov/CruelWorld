namespace CruelWorld.Creatures
{
    public interface ICreature
    {
        bool IsDead { get; }
        bool IsAlive { get; }
        int HitPoints { get; }
        int Strength { get; }        
        /// <summary>
        /// Take some damage
        /// </summary>
        /// <param name="amount">Total damage dealed amount</param>
        /// <returns>damage recieved amount</returns>
        int Suffer(int amount);
    }
}