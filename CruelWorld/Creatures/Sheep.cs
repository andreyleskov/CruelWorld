using System.Text;
using System.Threading.Tasks;

namespace CruelWorld
{

    public class Sheep: MortalCreature
    {
        public override int FightPower()
        {
            return 1;
        }

        public Sheep()
        {
            HitPoints = 2;
        }

    }

}
