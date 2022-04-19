﻿using Smartstore.Scheduling;

namespace Smartstore.Core.Search.Indexing
{
    public interface IIndexCollector
    {
        string Scope { get; }

        Task<AcquireWriterContext> CreateWriterContextAsync(AcquirementReason reason, TaskExecutionContext context);

        Task<IndexCollectorResult> CollectAsync(
            AcquireWriterContext context,
            DateTime? lastIndexedUtc,
            int continueDocumentId,
            Func<int, SearchDocumentType?, IIndexDocument> newDocument);
    }
}