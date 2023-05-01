using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Atlassian.Jira.Remote;

namespace Atlassian.Jira
{
    public class JiraNamedEntityCollection<T> : Collection<T>, IRemoteIssueFieldProvider where T : JiraNamedEntity
    {
        protected readonly Jira _jira;
        protected readonly string _projectKey;
        protected readonly string _fieldName;
        private readonly List<T> _originalList;

        internal JiraNamedEntityCollection(string fieldName, Jira jira, string projectKey, IList<T> list)
            : base(list)
        {
            _fieldName = fieldName;
            _jira = jira;
            _projectKey = projectKey;
            _originalList = new List<T>(list);
        }

        public static bool operator ==(JiraNamedEntityCollection<T> list, string value)
        {
            return list is null ? value == null : list.Any(v => v.Name == value);
        }

        public static bool operator !=(JiraNamedEntityCollection<T> list, string value)
        {
            return list is null ? value == null : list.Any(v => v.Name == value) is false;
        }

        public override bool Equals(object obj)
        {
            if (obj is JiraNamedEntityCollection<T> list)
            {
                return Enumerable.SequenceEqual(this, list);
            }

            return false;
        }

        public override int GetHashCode()
        {
            unchecked
            {
                int hash = 17;
                foreach (var item in this)
                {
                    hash = hash * 23 + (item != null ? item.GetHashCode() : 0);
                }

                return hash;
            }
        }

        /// <summary>
        /// Removes an entity by name.
        /// </summary>
        /// <param name="name">Entity name.</param>
        public void Remove(string name)
        {
            this.Remove(this.Items.First(c => c.Name.Equals(name, StringComparison.OrdinalIgnoreCase)));
        }

        Task<RemoteFieldValue[]> IRemoteIssueFieldProvider.GetRemoteFieldValuesAsync(CancellationToken token)
        {
            var fields = new List<RemoteFieldValue>();

            if (_originalList.Count() != Items.Count() || _originalList.Except(Items).Any())
            {
                var field = new RemoteFieldValue()
                {
                    id = _fieldName,
                    values = Items.Select(e => e.Id).ToArray()
                };
                fields.Add(field);
            }

            return Task.FromResult(fields.ToArray());
        }
    }
}
