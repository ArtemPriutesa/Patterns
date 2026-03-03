namespace Patterns.Model
{
    public class AMDCPU : ICPU
    {
        private string model;

        public AMDCPU(string model)
        {
            this.model = model;
        }

        public string GetCPU()
        {
            return $"AMD CPU: {model}";
        }

        public string ModelName()
        {
            return model;
        }
    }
}
