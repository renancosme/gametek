using System;
using System.Collections.Generic;
using System.Text;
using Unified.Domain.Interfaces;

namespace Unified.Infra.MrgreenAdapter
{
    public class MrgreenAdapterSettings : IMrgreenAdapterSettings
    {
        public string MrgreenUrl { get; }

        public MrgreenAdapterSettings(string mrgreenUrl)
        {
            MrgreenUrl = mrgreenUrl;
        }
    }
}
