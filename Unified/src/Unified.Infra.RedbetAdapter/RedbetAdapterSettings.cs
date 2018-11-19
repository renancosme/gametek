using Unified.Domain.Interfaces;

namespace Unified.Infra.RedbetAdapter
{
    public class RedbetAdapterSettings : IRedbetAdapterSettings
    {
        public string RedbetUrl { get; }

        public RedbetAdapterSettings(string redbetUrl)
        {
            RedbetUrl = redbetUrl;
        }
    }
}
