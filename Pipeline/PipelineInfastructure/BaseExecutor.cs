using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pipeline.PipelineInfastructure
{
    public abstract class BaseExecutor <T> : IExecutor<T>
    {
        private IExecutor<T> _nextPhrase;

        protected abstract T _Execute(T input);

        public T Execute(T input)
        {
            T retVal = _Execute(input);

            if (_nextPhrase != null)
            {
                retVal = _nextPhrase.Execute(retVal);
            }

            return retVal;
        }

        public void Register(IExecutor<T> nextPhrase)
        {
            _nextPhrase = nextPhrase;
        }
    }
}
