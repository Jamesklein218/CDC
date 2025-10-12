namespace CDC.Contract;

public interface ICdcChangeSink<T>
{
  Task SaveAsync(T entity, CancellationToken cancellationToken);
}
