// inspired by OTP

namespace Pattern.TemplateMethod
{
    public abstract class OTP
    {
        // define skeleton of an algorithm
        public void Send()
        {
            // hook
            string newOTP = this.Generate();

            // operation
            this.SaveCache(newOTP);
            string message = this.GetMessage(newOTP);
            this.SendNotification(message);
        }

        protected abstract void SaveCache(string otp);

        protected abstract string GetMessage(string otp);

        protected abstract void SendNotification(string message);

        protected virtual string Generate()
        {
            Random random = new Random();
            int otp = random.Next(100000, 999999);
            Console.WriteLine("Generated OTP");
            return otp.ToString();
        }
    }

    public class SMSOTP : OTP
    {
        protected override void SaveCache(string otp)
        {

            Console.WriteLine("SMS: save OTP in cache");
        }

        protected override string GetMessage(string otp)
        {
            return $"SMS: your OTP is {otp}";
        }

        protected override void SendNotification(string message)
        {
            Console.WriteLine("SMS: send notification to user");
        }
    }

    public class EmailOTP : OTP
    {
        protected override void SaveCache(string otp)
        {
            Console.WriteLine("Email: save OTP in cache");
        }

        protected override string GetMessage(string otp)
        {
            return $"Email: your OTP is {otp}";
        }

        protected override void SendNotification(string message)
        {
            Console.WriteLine("Email: send notification to user");
        }
    }

    public class TemplateMethod : ExamplePattern
    {
        public void RunExample()
        {
            Console.WriteLine("\nTemplate method example\n");

            OTP smsOTP = new SMSOTP();
            smsOTP.Send();

            OTP emailOTP = new EmailOTP();
            emailOTP.Send();
        }
    }
}