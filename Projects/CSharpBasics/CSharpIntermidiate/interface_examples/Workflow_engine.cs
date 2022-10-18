using System;
namespace CSharpIntermidiate.interface_examples
{
    public interface IActivity
    {
        void Execute();
    }

    public class UploadVideoToCloud : IActivity
    {
        public void Execute()
        {
            Console.WriteLine("Upload a video to a Cloud storage");
        }
    }

    public class CallWebServiceEncode : IActivity
    {
        public void Execute()
        {
            Console.WriteLine("There is a Video ready for encoding");
        }
    }

    public class SendEmailNotification : IActivity
    {
        public void Execute()
        {
            Console.WriteLine("EMAIL: Video encoding process has started");
        }
    }

    public class ChangeVideoStatusInDB : IActivity
    {
        public void Execute()
        {
            Console.WriteLine("Set Processing stauts in DB");
        }
    }

    public interface IWorkflow
    {
        void Add(IActivity activity);
        void Remove(IActivity activity);
        IEnumerable<IActivity> GetActivities();
    }

    public class Workflow : IWorkflow
    {
        public List<IActivity> activities { get; private set; }

        public Workflow()
        {
            activities = new List<IActivity>();
        }

        public Workflow(List<IActivity> _activities)
        {
            activities = _activities;
        }

        public void Add(IActivity activity)
        {
            activities.Add(activity);
        }

        public void Remove(IActivity activity)
        {
            activities.Remove(activity);
        }

        // IEnumerable is used to get a readonly copy of the list.
        public IEnumerable<IActivity> GetActivities()
        {
            return activities;
        }
    }

    public class WorkflowEngine
    {
        private readonly IWorkflow _workflow;

        public WorkflowEngine(IWorkflow workflow)
        {
            _workflow = workflow;
        }

        public void Run()
        {
            foreach (var activity in _workflow.GetActivities())
            {
                activity.Execute();
            }
        }
    }

}

