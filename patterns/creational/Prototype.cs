// inspired by DOTA 2 Meepo

namespace Pattern.Prototype
{
    public class Meepo
    {
        private int _meepoID;
        private int _level;
        private int _hp;
        private int _mana;
        private bool _isMainMeepo;
        private int _meepoAmount;

        public Meepo()
        {
            _meepoID = 1;
            _level = 16;
            _hp = 400;
            _mana = 200;
            _isMainMeepo = true;
            _meepoAmount = 1;
        }

        private void SetMeepoID(int id)
        {
            _meepoID = id;
        }

        // true -> main meepo
        // false -> clone meepo
        private void SetIsMainMeepo(bool isMainMeepo)
        {
            _isMainMeepo = isMainMeepo;
        }

        public Meepo Ultimate()
        {
            if (_meepoAmount >= 5)
            {
                Console.WriteLine("max meepo amount reached");
                return null;
            }
            if (!_isMainMeepo)
            {
                Console.WriteLine("only main meepo can use ultimate");
                return null;
            }
            Console.WriteLine("add new meepo");
            this._meepoAmount++;
            var newMeepo = new Meepo();
            newMeepo.SetMeepoID(_meepoAmount);
            newMeepo.SetIsMainMeepo(false);
            return newMeepo;
        }

        public void ShowStats()
        {
            Console.WriteLine($"Meepo {_meepoID} stats:");
            Console.Write($"Level: {_level}\t");
            Console.Write($"HP: {_hp}\t\t");
            Console.Write($"Mana: {_mana}\t");
            Console.WriteLine($"Is main meepo: {_isMainMeepo}");
            Console.WriteLine();
        }
    }


    public class Prototype : ExamplePattern
    {
        public void RunExample()
        {
            Console.WriteLine("\nPrototype example\n");
            Meepo meepo1 = new Meepo();
            meepo1.ShowStats();
            
            Meepo meepo2 = meepo1.Ultimate();
            meepo2.ShowStats();
            
            Meepo meepo3 = meepo1.Ultimate();
            meepo3.ShowStats();

            Console.WriteLine("Now 3 Meepos want to bang you");
        }
    }
}