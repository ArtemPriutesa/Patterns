using Patterns.Model;

namespace Patterns.Structural
{
    public abstract class CpuDecorator : ICPU
    {
        protected readonly ICPU _cpu;

        protected CpuDecorator(ICPU cpu)
        {
            _cpu = cpu;
        }
        public virtual string GetCPU()
        {
            return _cpu.GetCPU();
        }
        public virtual string ModelName()
        {
            return _cpu.ModelName();
        }
        
        public virtual string GetDetails()
        {
            return _cpu.GetDetails();
        }

        public virtual string GetName()
        {
            return _cpu.GetName();
        }

        public virtual double GetPrice()
        {
            return _cpu.GetPrice();
        }

        public virtual void DisplayDetails(int depth)
        {
            _cpu.DisplayDetails(depth);
        }
    }
}