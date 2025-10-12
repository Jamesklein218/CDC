using System;

namespace CDC.Contract;

public interface ICdcChangeSource<T>
{
  /// <summary>
  /// Batch process raw changes
  /// </summary>
  Task<IEnumerable<T>> GetRawChangesAsync(CancellationToken cancellationToken);

  /// <summary>
  /// Mark the changes as processed
  /// </summary>
  Task MarkChangesAsProcessedAsync(IEnumerable<T> changes, CancellationToken cancellationToken);
}
