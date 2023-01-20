using Core;
using System;
using System.Threading;
using System.Threading.Tasks;
using static System.Collections.Specialized.BitVector32;

namespace wpf_advance.Core
{
    public class TaskManager : ITaskManager
    {
        private void LogError(Exception ex)
        {
            IoC.Logger.Log($"An unexpected error ocured running a IoC.IoC.Task.Run. \n{ex.Message}", LogFactoryLevel.Debag);
        }
        public async Task Run(Action action)
        {
            try
            {
                await IoC.Task.Run(action);
            }
            catch (Exception ex)
            {
                LogError(ex);
                throw;
            }
        }

        public async Task Run(Action action, CancellationToken cancellationToken)
        {
            try
            {
                await IoC.Task.Run(action, cancellationToken);
            }
            catch (Exception ex)
            {
                LogError(ex);
                throw;
            }
        }

        public Task<TResult> Run<TResult>(Func<TResult> function)
        {
            try
            {
                return IoC.Task.Run(function);
            }
            catch (Exception ex)
            {
                LogError(ex);
                throw;
            }
        }

        public Task<TResult> Run<TResult>(Func<TResult> function, CancellationToken cancellationToken)
        {
            try
            {
                return IoC.Task.Run(function, cancellationToken);
            }
            catch (Exception ex)
            {
                LogError(ex);
                throw;
            }
        }

        public async Task Run(Func<Task> function)
        {
            try
            {
                await IoC.Task.Run(function);
            }
            catch (Exception ex)
            {
                LogError(ex);
                throw;
            }
        }

        public async Task Run(Func<Task> function, CancellationToken cancellationToken)
        {
            try
            {
                await IoC.Task.Run(function, cancellationToken);
            }
            catch (Exception ex)
            {
                LogError(ex);
                throw;
            }
        }

        public Task<TResult> Run<TResult>(Func<Task<TResult>> function)
        {
            try
            {
                return IoC.Task.Run(function);
            }
            catch (Exception ex)
            {
                LogError(ex);
                throw;
            }
        }

        public Task<TResult> Run<TResult>(Func<Task<TResult>> function, CancellationToken cancellationToken)
        {
            try
            {
                return IoC.Task.Run(function, cancellationToken);
            }
            catch (Exception ex)
            {
                LogError(ex);
                throw;
            }
        }
    }
}
