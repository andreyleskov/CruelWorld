using System.Text;
using System.Threading.Tasks;

namespace CruelWorld
{
    public class Sheep: MortalCreature
    {
        public Sheep(): base(2)
        {
        }

        public override int FightPower()
        {
            return 1;
        }
    }
}
