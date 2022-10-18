 using System;
namespace CSharpIntermidiate.class_examples
{
    public class StopWatch
    {

        // Auto-imoplement property
        public DateTime startTime { get; private set; }
        public bool isRunning { get; private set; }

        public void start()
        {
            if (isRunning)
            {
                throw new InvalidOperationException("Stopwatch is already running!");
            }
            startTime = DateTime.Now;
            isRunning = true;
        }

        public TimeSpan stop()
        {
            if (!isRunning)
            {
                throw new InvalidOperationException("Stopwatch is not running!");
            }

            isRunning = false;

            return (startTime - DateTime.Now).Duration(); 
        }
    }

    public class Post
    {
        private string _title;
        private string _description;
        private DateTime _datetime;

        //property
        public int _vote { get; set; }

        public Post(string title, string description)
        {
            this._title = title;
            this._description = description;
            this._datetime = DateTime.Now;
            this._vote = 0;
        }

        // Property: Dont require () and for setter use the keyword "value" as the input.
        public string Title
        {

            get { return _title; }
            set
            {
                if (string.IsNullOrEmpty(value) || string.IsNullOrWhiteSpace(value))
                    throw new ArgumentNullException("Title cannot be null or empty");
                _title = value;
            }
        }

        public string Description
        {
            get { return _description; }
            set
            {
                if (string.IsNullOrEmpty(value) || string.IsNullOrWhiteSpace(value))
                    throw new ArgumentNullException("Description cannot be null or empty");
                _description = value;
            }
        }

        public DateTime Datetime
        {
            get { return _datetime; }
        }

        public void IncreaseVote()
        {
            this._vote++;
        }

        public void DecreaseVote()
        {
            this._vote--;
        }
    }
}

