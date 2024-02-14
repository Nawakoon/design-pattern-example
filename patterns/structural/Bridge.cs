// inspired by refactoring.guru

namespace Pattern.Bridge
{
    public interface ISoundDevice
    {
        public bool IsOn { get; set; }
        public int Volume { get; set; }
        public string Name { get; set; }
        void turnOn();
        void turnOff();
        void SetVolume(int volume);
        int GetVolume();
    }

    public class SoundDevice : ISoundDevice
    {
        public bool IsOn { get; set; }
        public int Volume { get; set; }
        public string Name { get; set; }

        public SoundDevice(string name)
        {
            IsOn = false;
            Volume = 0;
            Name = name;
        }

        public void turnOn()
        {
            IsOn = true;
            Console.WriteLine($"{Name} is on");
        }

        public void turnOff()
        {
            IsOn = false;
            Console.WriteLine($"{Name} is off");
        }

        public void SetVolume(int volume)
        {
            Volume = volume;
            Console.WriteLine($"{Name} volume is set to {volume}");
        }

        public int GetVolume()
        {
            return Volume;
        }
    }

    public abstract class SoundDeviceRemote
    {
        protected SoundDevice SoundDevice { get; set; }

        public SoundDeviceRemote(SoundDevice soundDevice)
        {
            SoundDevice = soundDevice;
        }

        public void TurnOn()
        {
            SoundDevice.turnOn();
        }

        public void TurnOff()
        {
            SoundDevice.turnOff();
        }

        public void SetVolume(int volume)
        {
            SoundDevice.SetVolume(volume);
        }
    }

    public class ButtonBasedSoundDeviceRemote : SoundDeviceRemote
    {

            
        public ButtonBasedSoundDeviceRemote(SoundDevice soundDevice) : base(soundDevice)
        {
        }

        public void PressButton(string button)
        {
            if (button == "on")
            {
                TurnOn();
            }
            else if (button == "off")
            {
                TurnOff();
            }
            else if (button == "up")
            {
                if (SoundDevice.IsOn)
                {
                    if (SoundDevice.GetVolume() < 100) {
                        SetVolume(SoundDevice.GetVolume() + 10);
                    }
                    if (SoundDevice.GetVolume() > 100) {
                        SetVolume(100);
                    }
                }
            }
            else if (button == "down")
            {
                if (SoundDevice.IsOn)
                {
                    if (SoundDevice.GetVolume() > 0) {
                        SetVolume(SoundDevice.GetVolume() - 10);
                    }
                    if (SoundDevice.GetVolume() < 0) {
                        SetVolume(0);
                    }
                }
            }
        }
    }

    public class SliderBasedSoundDeviceRemote : SoundDeviceRemote
    {
        public SliderBasedSoundDeviceRemote(SoundDevice soundDevice) : base(soundDevice)
        {
        }

        public void Slide(int volume)
        {
            if (SoundDevice.IsOn)
            {
                SetVolume(volume);
            }
        }
    }

    public class Bridge : ExamplePattern
    {
        public void RunExample()
        {
            Console.WriteLine("\nBridge example\n");

            SoundDevice classicSpeaker = new SoundDevice("Classic Speaker");
            ButtonBasedSoundDeviceRemote classicSpeakerRemote = new ButtonBasedSoundDeviceRemote(classicSpeaker);

            SoundDevice smartSpeaker = new SoundDevice("Smart Speaker");
            SliderBasedSoundDeviceRemote smartSpeakerRemote = new SliderBasedSoundDeviceRemote(smartSpeaker);

            classicSpeakerRemote.PressButton("on");
            classicSpeakerRemote.PressButton("up");
            classicSpeakerRemote.PressButton("up");
            classicSpeakerRemote.PressButton("down");
            classicSpeakerRemote.PressButton("off");

            smartSpeakerRemote.TurnOn();
            smartSpeakerRemote.Slide(50);
            smartSpeakerRemote.Slide(70);
            smartSpeakerRemote.TurnOff();
        }
    }
}