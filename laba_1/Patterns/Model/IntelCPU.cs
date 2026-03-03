namespace Patterns.Model
{
    public class IntelCPU : ICPU
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
}
