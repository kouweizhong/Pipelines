using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pipeline.PipelineInfastructure
{
    public static class Pipeline<T>
    {
        public static T Execute(IEnumerable<IExecutor<T>> processes, T processItem)
        {
            if (processItem == null)
            {
                return default(T);
            }

            IExecutor<T> root = null;
            IExecutor<T> previous = null;

            foreach (IExecutor<T> step in _GetNextProcessStep(processes))
            {
                if (root == null)
                {
                    root = step;
                }
                else
                {
                    previous.Register(step);
                }
                previous = step;
            }

            return root == null ? default(T) : root.Execute(processItem);
        }

        private static IEnumerable<IExecutor<T>> _GetNextProcessStep(IEnumerable<IExecutor<T>> processes)
        {
            foreach (var process in processes)
            {
                yield return process;
            }
        }
    }
}
