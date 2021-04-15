using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TreasureGameLib.BonusesRewards
{
    public class AbilityUpBonusFactory : BonusFactory
    {
        public AbilityUpBonusFactory(int party, float bonusWidth, float bonusHeight)
            : base (party, bonusWidth, bonusHeight)
        { }

        public AbilityUpBonusFactory(float bonusWidth,float bonusHeight)
            : this (standartParty, bonusWidth, bonusHeight)
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
