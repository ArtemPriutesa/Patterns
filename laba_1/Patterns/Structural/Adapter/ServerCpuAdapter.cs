using Patterns.Model;

namespace Patterns.Structural
{
    public class ServerCpuAdapter : ICPU
    {
        private OldServerProcessor oldProcessor;

        public ServerCpuAdapter(OldServerProcessor oldProcessor)
        {
            this.oldProcessor = oldProcessor;
        }

        public string GetCPU()
        {
            return $"Adapted CPU: {oldProcessor.GetIdentifier()} with specs: {oldProcessor.TechnicalSpecs}";
        }

        public string ModelName()
        {
            return oldProcessor.GetIdentifier();
        }
    }
}