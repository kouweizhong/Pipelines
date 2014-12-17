using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pipeline.PipelineInfastructure
{
    public abstract class BaseExecutor <T> : IExecutor<T>
    {
        private IExecutor<T> _next;

        protected abstract T _Execute(T input);

        public T Execute(T input)
        {
            T ret = _Execute(input);

            if (_next != null)
            {
                ret = _next.Execute(ret);
            }

            return ret;
        }

        public void Register(IExecutor<T> next)
        {
            _next = next;
        }
    }
}
