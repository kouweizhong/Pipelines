using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pipeline.PipelineInfastructure
{
    public interface IExecutor<T>
    {
        T Execute(T input);
        void Register(IExecutor<T> nextPhrase);
    }
}
