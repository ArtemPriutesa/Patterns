namespace laba_1.creational.Model
{
    public interface ICPU
    {
        string GetCPU();
        string ModelName();
    }
    class IntelCPU : ICPU
    {
        private string model;
        public IntelCPU(string model)
        {
            this.model = model;
        }
        public string GetCPU()
        {
            return $"Intel CPU: {model}";
        }
        public string ModelName()
        {
            return model;
        }
    }
    class AMDCPU : ICPU
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