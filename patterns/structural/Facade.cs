// inspired by hospital

namespace Pattern.Facade
{
    public class PatientDemographicsStore
    {
        public class PatientDemographicData
        {
            public string name { get; set; }
            public string gender { get; set; }
            public int age { get; set; }

            public PatientDemographicData(string _name, string _gender, int _age)
            {
                name = _name;
                gender = _gender;
                age = _age;
            }    
        }
        public string name { get; set; }
        public List<PatientDemographicData> data { get; set; }
        
        public PatientDemographicsStore(string _name)
        {
            name = _name;
            data = new List<PatientDemographicData>();
        }
        public void Add(string _name, string _gender, int _age)
        {
            data.Add(new PatientDemographicData(_name, _gender, _age));
        }
        public void Remove(string _name)
        {
            data.RemoveAll(x => x.name == _name);
        }
        public PatientDemographicData Get(string _name)
        {
            return data.Find(x => x.name == _name);
        }
    }

    
    public class PatientDiagonisStore
    {
        public class PatientDiagonisData
        {
            public string name { get; set; }
            public string diagnosis { get; set; }
            public string detail { get; set; }

            public PatientDiagonisData(string _name, string _diagnosis, string _detail)
            {
                name = _name;
                diagnosis = _diagnosis;
                detail = _detail;
            }    
        }
        public string name { get; set; }
        public List<PatientDiagonisData> data { get; set; }
        
        public PatientDiagonisStore(string _name)
        {
            name = _name;
            data = new List<PatientDiagonisData>();
        }
        public void Add(string _name, string _diagnosis, string _treatment)
        {
            data.Add(new PatientDiagonisData(_name, _diagnosis, _treatment));
        }
        public void Remove(string _name)
        {
            data.RemoveAll(x => x.name == _name);
        }
        public PatientDiagonisData Get(string _name)
        {
            return data.Find(x => x.name == _name);
        }
    }
    
    
    public class PatientService
    {
        public string name { get; set; }
        private PatientDemographicsStore demographicsStore { get; set; }
        private PatientDiagonisStore diagonisStore { get; set; }
        
        public PatientService(string _name, PatientDemographicsStore _demographicsStore, PatientDiagonisStore _diagonisStore)
        {
            name = _name;
            demographicsStore = _demographicsStore;
            diagonisStore = _diagonisStore;
        }

        public void AddPatient(string _name, string _gender, int _age)
        {
            demographicsStore.Add(_name, _gender, _age);
            Console.WriteLine("Patient added");
        }

        public void RemovePatient(string _name)
        {
            demographicsStore.Remove(_name);
            Console.WriteLine("Patient removed");
        }

        public void AddDiagnostic(string _name, string _diagnosis, string _treatment)
        {
            var patient = demographicsStore.Get(_name);
            if (patient == null)
            {
                Console.WriteLine("Patient not found");
                Console.WriteLine("Please add patient first");
                return;
            }
            diagonisStore.Add(_name, _diagnosis, _treatment);
            Console.WriteLine("Diagnostic added");
        }

        public void RemoveDiagnostic(string _name)
        {
            diagonisStore.Remove(_name);
            Console.WriteLine("Diagnostic removed");
        }

        public void PrintPatientReport(string _name)
        {
            var patient = demographicsStore.Get(_name);
            if (patient == null)
            {
                Console.WriteLine("Patient not found");
                return;
            }
            var diagnostic = diagonisStore.Get(_name);
            Console.WriteLine("Patient: " + patient.name);
            if (diagnostic != null)
            {
                Console.WriteLine("Diagnosis: " + diagnostic.diagnosis);
                Console.WriteLine("Detail: " + diagnostic.detail);
            }
            else
            {
                Console.WriteLine("No diagnosis found");
            }
        }
    }

    public class Facade : ExamplePattern
    {
        public void RunExample()
        {
            Console.WriteLine("\nFacade example\n");

            var patientDemographicsStore = new PatientDemographicsStore("PatientDemographicsStore");
            var patientDiagonisStore = new PatientDiagonisStore("PatientDiagonisStore");

            var patientService = new PatientService(
                "PatientService",
                patientDemographicsStore,
                patientDiagonisStore
            );

            patientService.AddPatient("John Doe", "male", 32);
            patientService.AddDiagnostic("John Doe", "flu", "rest and drink water");
            patientService.PrintPatientReport("John Doe");

            patientService.PrintPatientReport("Jane Smith");
        }
    }
}