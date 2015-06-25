namespace Cashbox.DataAccess
{
    internal interface IUnitOfWorkFactory
    {
        IUnitOfWork Create();
    }
}
