namespace SimpleFactory.Controllers
{
    public class DefaultMessageProvider : IMessageProvider
    {
        public static int ExecutionCount { get; set; }

        #region IMessageProvider Members

        public string GetMessage()
        {
            return string.Format("I've been called {0} times.", ExecutionCount++);
        }

        #endregion
    }
}