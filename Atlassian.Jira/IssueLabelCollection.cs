using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Atlassian.Jira.Remote;

namespace Atlassian.Jira
{
    /// <summary>
    /// Collection of labels for an issue.
    /// </summary>
    public class IssueLabelCollection : List<string>, IRemoteIssueFieldProvider
    {
        private readonly List<string> _originalLabels;

        /// <summary>
        /// Creates a new instance of IssueLabelCollection.
        /// </summary>
        /// <param name="labels">Labels to seed into this collection</param>
        public IssueLabelCollection(IList<string> labels)
            : base(labels)
        {
            _originalLabels = new List<string>(labels);
        }

        /// <summary>
        /// Adds labels to this collection.
        /// </summary>
        /// <param name="labels">The list of labels to add.</param>
        public void Add(params string[] labels)
        {
            this.AddRange(labels);
        }

        public static bool operator ==(IssueLabelCollection list, string value)
        {
            return list is null ? value == null : list.Any(v => v == value);
        }

        public static bool operator !=(IssueLabelCollection list, string value)
        {
            return list is null ? value == null : list.Any(v => v == value) is false;
        }

        public override bool Equals(object obj)
        {
            if (obj is IssueLabelCollection list)
            {
                return this.SequenceEqual(list);
            }

            return false;
        }

        public override int GetHashCode()
        {
            unchecked
            {
                int hash = 17;
                foreach (string label in this)
                {
                    hash = hash * 23 + (label != null ? label.GetHashCode() : 0);
                }

                return hash;
            }
        }

        Task<RemoteFieldValue[]> IRemoteIssueFieldProvider.GetRemoteFieldValuesAsync(CancellationToken token)
        {
            var fieldValues = new List<RemoteFieldValue>();

            if (_originalLabels.Count != this.Count || this.Except(_originalLabels).Any())
            {
                fieldValues.Add(new RemoteFieldValue()
                {
                    id = "labels",
                    values = this.ToArray()
                });
            }

            return Task.FromResult(fieldValues.ToArray());
        }
    }
}
