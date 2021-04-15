using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TreasureGameLib.BonusesRewards
{
    public class AbilityDownBonusFactory : BonusFactory
    {
        public AbilityDownBonusFactory(int party, float bonusWidth, float bonusHeight)
            : base(party, bonusWidth, bonusHeight)
        { }

        public AbilityDownBonusFactory(float bonusWidth, float bonusHeight)
            : this(standartParty, bonusWidth, bonusHeight)
        { }

        public override Bonus[] CreateNumber(int number)
        {
            throw new NotImplementedException();
        }

        public override Bonus[] CreateParty()
        {
            throw new NotImplementedException();
        }

        public override Bonus CreateSingle()
        {
            throw new NotImplementedException();
        }
    }
}
