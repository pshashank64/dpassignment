using NagarroTraining.MVC.BusinessDomain.Operations;

namespace NagarroTraining.MVC.BusinessDomain.EventAbstractFactory
{
    /// <summary>
    /// Defining interface for abstract factory method
    /// </summary>
    public interface IEventAbstract
    {
        EventOperations CreateEventOperations();
    }
}
