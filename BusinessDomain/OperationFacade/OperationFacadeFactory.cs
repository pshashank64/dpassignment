using NagarroTraining.MVC.BusinessDomain.Operations;

namespace BusinessDomain.OperationsFacade
{
    /// <summary>
    /// Creates the constructors of facade using the factory design pattern
    /// </summary>
    public class OperationFacadeFactory: IOperation
    {
        public OperationFacade CreateOperationFacade()
        {
            EventOperations eventOperations = new EventOperations();
            InvitationOperations invitationOperations = new InvitationOperations();
            UserOperation userOperation = new UserOperation();

            return new OperationFacade();
        }
    }
}
