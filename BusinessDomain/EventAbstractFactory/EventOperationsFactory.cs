using NagarroTraining.MVC.BusinessDomain.Operations;

namespace NagarroTraining.MVC.BusinessDomain.EventAbstractFactory
{
    /// <summary>
    /// To create objects of event operations using abstract factory
    /// </summary>
    public class EventOperationsFactory: IEventAbstract
    {
        public EventOperations CreateEventOperations()
        {
            return new EventOperations();
        }
    }
}
