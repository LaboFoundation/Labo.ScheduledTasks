namespace Labo.ScheduledTasks.Core.Data
{
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.Linq;

    using Labo.Common.Data.Repository;
    using Labo.Common.Data.Session;
    using Labo.Common.Exceptions;
    using Labo.ScheduledTasks.Core.Model;

    /// <summary>
    /// The database scheduled task storage class.
    /// </summary>
    public sealed class DbScheduledTaskStorage : IScheduledTaskStorage
    {
        /// <summary>
        /// The session scope provider.
        /// </summary>
        private readonly ISessionScopeProvider m_SessionScopeProvider;

        /// <summary>
        /// Initializes a new instance of the <see cref="DbScheduledTaskStorage"/> class.
        /// </summary>
        /// <param name="sessionScopeProvider">
        /// The session scope provider.
        /// </param>
        public DbScheduledTaskStorage(ISessionScopeProvider sessionScopeProvider)
        {
            m_SessionScopeProvider = sessionScopeProvider;
        }

        /// <summary>
        /// Deletes the task.
        /// </summary>
        /// <param name="taskId">The task unique identifier.</param>
        public void DeleteTask(int taskId)
        {
            using (ISessionScope sessionScope = m_SessionScopeProvider.CreateSessionScope())
            {
                sessionScope.GetRepository<ScheduledTask>().Delete(x => x.Id == taskId);

                sessionScope.Complete();
            }
        }

        /// <summary>
        /// Gets the task by unique identifier.
        /// </summary>
        /// <param name="taskId">The task unique identifier.</param>
        /// <returns>
        /// The <see cref="ScheduledTask"/>.
        /// </returns>
        public ScheduledTask GetTaskById(int taskId)
        {
            using (ISessionScope sessionScope = m_SessionScopeProvider.CreateSessionScope())
            {
                return sessionScope.GetRepository<ScheduledTask>().Query().SingleOrDefault(x => x.Id == taskId);
            }
        }

        /// <summary>
        /// Gets the type of the task by.
        /// </summary>
        /// <param name="type">The type.</param>
        /// <returns>Scheduled task.</returns>
        public ScheduledTask GetTaskByType(string type)
        {
            using (ISessionScope sessionScope = m_SessionScopeProvider.CreateSessionScope())
            {
                return sessionScope.GetRepository<ScheduledTask>().Query().SingleOrDefault(x => x.Type == type);
            }
        }

        /// <summary>
        /// Gets all tasks.
        /// </summary>
        /// <returns>Task list.</returns>
        public IList<ScheduledTask> GetAllTasks()
        {
            using (ISessionScope sessionScope = m_SessionScopeProvider.CreateSessionScope())
            {
                return sessionScope.GetRepository<ScheduledTask>().LoadAll();
            }
        }

        /// <summary>
        /// Inserts the task.
        /// </summary>
        /// <param name="task">The task.</param>
        public void InsertTask(ScheduledTask task)
        {
            using (ISessionScope sessionScope = m_SessionScopeProvider.CreateSessionScope())
            {
                IRepository<ScheduledTask> repository = sessionScope.GetRepository<ScheduledTask>();

                ValidateTask(repository, task);

                repository.Insert(task);

                sessionScope.Complete();
            }
        }

        /// <summary>
        /// Updates the task.
        /// </summary>
        /// <param name="task">The task.</param>
        public void UpdateTask(ScheduledTask task)
        {
            using (ISessionScope sessionScope = m_SessionScopeProvider.CreateSessionScope())
            {
                IRepository<ScheduledTask> repository = sessionScope.GetRepository<ScheduledTask>();

                ValidateTask(repository, task);

                repository
                    .UpdateProperties(
                        task,
                        x => x.Id,
                        x => x.Enabled,
                        x => x.Name,
                        x => x.RunOnlyOnce,
                        x => x.Seconds,
                        x => x.StopOnError,
                        x => x.Type);

                sessionScope.Complete();
            }
        }

        /// <summary>
        /// Updates the start date.
        /// </summary>
        /// <param name="taskId">The task unique identifier.</param>
        /// <param name="startDateUtc">The start date UTC.</param>
        public void UpdateStartDate(int taskId, DateTime startDateUtc)
        {
            using (ISessionScope sessionScope = m_SessionScopeProvider.CreateSessionScope(SessionScopeOption.RequiresNew))
            {
                ScheduledTask task = new ScheduledTask { Id = taskId, LastStartUtc = startDateUtc };

                sessionScope.GetRepository<ScheduledTask>().UpdateProperties(task, x => x.Id, x => x.LastStartUtc);

                sessionScope.Complete();
            }
        }

        /// <summary>
        /// Updates the end date.
        /// </summary>
        /// <param name="taskId">The task unique identifier.</param>
        /// <param name="endDateUtc">The end date UTC.</param>
        /// <param name="success">if set to <c>true</c> [success].</param>
        public void UpdateEndDate(int taskId, DateTime endDateUtc, bool success)
        {
            using (ISessionScope sessionScope = m_SessionScopeProvider.CreateSessionScope(SessionScopeOption.RequiresNew))
            {
                ScheduledTask task = new ScheduledTask { Id = taskId, LastEndUtc = endDateUtc };

                IRepository<ScheduledTask> repository = sessionScope.GetRepository<ScheduledTask>();

                if (success)
                {
                    task.LastSuccessUtc = endDateUtc;

                    repository.UpdateProperties(task, x => x.Id, x => x.LastEndUtc, x => x.LastSuccessUtc);
                }
                else
                {
                    repository.UpdateProperties(task, x => x.Id, x => x.LastEndUtc);
                }

                sessionScope.Complete();
            }
        }

        /// <summary>
        /// Validates the task.
        /// </summary>
        /// <param name="repository">The repository.</param>
        /// <param name="task">The task.</param>
        /// <exception cref="Labo.Common.Exceptions.UserLevelException">
        /// type must be unique
        /// or
        /// name must be unique
        /// </exception>
        private static void ValidateTask(IRepository<ScheduledTask> repository, ScheduledTask task)
        {
            if (repository.Query().Any(x => x.Type == task.Type && x.Id != task.Id))
            {
                throw new UserLevelException(string.Format(CultureInfo.CurrentCulture, "Task with type '{0}' already exists.", task.Type));
            }

            if (repository.Query().Any(x => x.Name == task.Name && x.Id != task.Id))
            {
                throw new UserLevelException(string.Format(CultureInfo.CurrentCulture, "Task with name '{0}' already exists.", task.Type));
            }
        }
    }
}