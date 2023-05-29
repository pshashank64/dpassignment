using NagarroTraining.MVC.BusinessDomain.Operations;

namespace BusinessDomain.OperationsFacade
{
    /// <summary>
    /// Interface for facade design implementation
    /// </summary>
    public interface IOperation
    {
        OperationFacade CreateOperationFacade();
    }
}
