namespace CDC.Contract;

public interface ICdcProcessor
{
  /// <summary>
  /// Executes one full CDC cycle: Read -> Process -> Store/Publish
  /// </summary>
  Task ProcessChangesAsync(CancellationToken token);
}
