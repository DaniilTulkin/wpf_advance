using System;
using System.Threading;
using System.Threading.Tasks;

namespace wpf_advance.Core
{
    public interface ITaskManager
    {
        Task Run(Action action);
        Task Run(Action action, CancellationToken cancellationToken);
        Task<TResult> Run<TResult>(Func<TResult> function);
        Task<TResult> Run<TResult>(Func<TResult> function, CancellationToken cancellationToken);
        Task Run(Func<Task> function);
        Task Run(Func<Task> function, CancellationToken cancellationToken);
        Task<TResult> Run<TResult>(Func<Task<TResult>> function);
        Task<TResult> Run<TResult>(Func<Task<TResult>> function, CancellationToken cancellationToken);
    }
}
