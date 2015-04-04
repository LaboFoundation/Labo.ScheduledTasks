namespace Labo.ScheduledTasks.Core.Data
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using Labo.Common.Data.Repository;
    using Labo.Common.Data.Session;
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
                sessionScope.GetRepository<ScheduleTask>().Delete(x => x.Id == taskId);

                sessionScope.Complete();
            }
        }

        /// <summary>
        /// Gets the task by unique identifier.
        /// </summary>
        /// <param name="taskId">The task unique identifier.</param>
        /// <returns>
        /// The <see cref="ScheduleTask"/>.
        /// </returns>
        public ScheduleTask GetTaskById(int taskId)
        {
            using (ISessionScope sessionScope = m_SessionScopeProvider.CreateSessionScope())
            {
                return sessionScope.GetRepository<ScheduleTask>().Query().SingleOrDefault(x => x.Id == taskId);
            }
        }

        /// <summary>
        /// Gets the type of the task by.
        /// </summary>
        /// <param name="type">The type.</param>
        /// <returns></returns>
        public ScheduleTask GetTaskByType(string type)
        {
            using (ISessionScope sessionScope = m_SessionScopeProvider.CreateSessionScope())
            {
                return sessionScope.GetRepository<ScheduleTask>().Query().SingleOrDefault(x => x.Type == type);
            }
        }

        /// <summary>
        /// Gets all tasks.
        /// </summary>
        /// <returns></returns>
        public IList<ScheduleTask> GetAllTasks()
        {
            using (ISessionScope sessionScope = m_SessionScopeProvider.CreateSessionScope())
            {
                return sessionScope.GetRepository<ScheduleTask>().LoadAll();
            }
        }

        /// <summary>
        /// Inserts the task.
        /// </summary>
        /// <param name="task">The task.</param>
        public void InsertTask(ScheduleTask task)
        {
            using (ISessionScope sessionScope = m_SessionScopeProvider.CreateSessionScope())
            {
                sessionScope.GetRepository<ScheduleTask>().Insert(task);

                sessionScope.Complete();
            }
        }

        /// <summary>
        /// Updates the task.
        /// </summary>
        /// <param name="task">The task.</param>
        public void UpdateTask(ScheduleTask task)
        {
            using (ISessionScope sessionScope = m_SessionScopeProvider.CreateSessionScope())
            {
                sessionScope.GetRepository<ScheduleTask>().Update(task);

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
                ScheduleTask task = new ScheduleTask { Id = taskId, LastStartUtc = startDateUtc };

                sessionScope.GetRepository<ScheduleTask>().UpdateProperties(task, x => x.Id, x => x.LastStartUtc);

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
                ScheduleTask task = new ScheduleTask { Id = taskId, LastEndUtc = endDateUtc };

                IRepository<ScheduleTask> repository = sessionScope.GetRepository<ScheduleTask>();

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
    }
}