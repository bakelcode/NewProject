namespace NewsProject.Server.Repositories.Intefaces
{
    public interface MainInteface<T> where T : class
    {
        IEnumerable<T> GetAllDate(string[] includes = null);
        T GetRowById(int id);
        T AddRow(T model);
        T UpdateRow(T model);
        void DeleteRow(int id);
    }
}
