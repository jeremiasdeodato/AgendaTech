namespace AgendasTech.Domain.Core.Interfaces
{
    public interface IRepositoryBase<T> where T : class
    {
        IQueryable<T> Obter();
        void Inserir(T model);
    }
}
