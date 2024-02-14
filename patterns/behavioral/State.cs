// inspired by android 

namespace Pattern.State
{
    // context
    public class Phone
    {
        private PhoneState _state;

        public Phone()
        {
            _state = new Locked(this);
        }

        public void ChangePhoneState(PhoneState state)
        {
            // Console.WriteLine("Phone turn to: " + state.GetType().Name);
            _state = state;
            return;
        }

        public void PressScreenButton()
        {
            _state.PressScreenButton();
        }

        public void PressVolumeDown()
        {
            _state.PressVolumeDown();
        }

        public void PressVolumeUp()
        {
            _state.PressVolumeUp();
        }
    }


    public abstract class PhoneState
    {
        protected Phone _phone;

        public void SetPhone(Phone phone)
        {
            _phone = phone;
        }
        
        public abstract void PressScreenButton();

        public abstract void PressVolumeUp();

        public abstract void PressVolumeDown();
    }

    public class Locked : PhoneState
    {
        public Locked(Phone phone)
        {
            this._phone = phone;
        }

        public override void PressScreenButton()
        {
            Console.WriteLine("unlock the screen");
            _phone.ChangePhoneState(new Unlocked(this._phone));
        }

        public override void PressVolumeUp() {
            Console.WriteLine("...");
        }

        public override void PressVolumeDown() {
            Console.WriteLine("...");
        }
    }

    public class Unlocked : PhoneState
    {
        public Unlocked(Phone phone)
        {
            this._phone = phone;
        }

        public override void PressScreenButton()
        {
            Console.WriteLine("lock the screen");
            _phone.ChangePhoneState(new Locked(this._phone));
        }

        public override void PressVolumeUp() {
            Console.WriteLine("volume up");
        }

        public override void PressVolumeDown() {
            Console.WriteLine("volume down");
        }
    }

    public class State : ExamplePattern
    {
        public void RunExample()
        {
            Console.WriteLine("\nState example\n");

            var myPhone = new Phone();

            myPhone.PressVolumeDown();
            myPhone.PressVolumeUp();

            myPhone.PressScreenButton();
            myPhone.PressVolumeDown();
            myPhone.PressVolumeUp();

            myPhone.PressScreenButton();
            myPhone.PressVolumeDown();
        }
    }
}