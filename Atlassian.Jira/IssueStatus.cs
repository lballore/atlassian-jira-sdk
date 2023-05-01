using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Atlassian.Jira.Remote;

namespace Atlassian.Jira
{
    /// <summary>
    /// The status of the issue as defined in JIRA
    /// </summary>
    public class IssueStatus : JiraNamedConstant
    {
        /// <summary>
        /// Creates an instance of the IssueStatus based on a remote entity.
        /// </summary>
        public IssueStatus(RemoteStatus remoteStatus)
            : base(remoteStatus)
        {
            StatusCategory = remoteStatus.statusCategory != null ?
                new IssueStatusCategory(remoteStatus.statusCategory) :
                null;
        }

        internal IssueStatus(string id, string name = null)
            : base(id, name)
        {
        }

        protected override async Task<IEnumerable<JiraNamedEntity>> GetEntitiesAsync(Jira jira, CancellationToken token)
        {
            var results = await jira.Statuses.GetStatusesAsync(token).ConfigureAwait(false);
            return results as IEnumerable<JiraNamedEntity>;
        }

        /// <summary>
        /// The category assigned to this issue status.
        /// </summary>
        public IssueStatusCategory StatusCategory { get; }

        /// <summary>
        /// Allows assignation by name
        /// </summary>
        public static implicit operator IssueStatus(string name)
        {
            if (name != null)
            {
                if (int.TryParse(name, out _))
                {
                    return new IssueStatus(name);
                }
                else
                {
                    return new IssueStatus(null, name);
                }
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// Operator overload to simplify LINQ queries
        /// </summary>
        /// <remarks>
        /// Allows calls in the form of issue.Priority == "High"
        /// </remarks>
        public static bool operator ==(IssueStatus entity, string name)
        {
            if (entity is null)
            {
                return name == null;
            }
            else if (name == null)
            {
                return false;
            }
            else
            {
                return entity.Name == name;
            }
        }

        /// <summary>
        /// Operator overload to simplify LINQ queries
        /// </summary>
        /// <remarks>
        /// Allows calls in the form of issue.Priority != "High"
        /// </remarks>
        public static bool operator !=(IssueStatus entity, string name)
        {
            if (entity is null)
            {
                return name != null;
            }
            else if (name == null)
            {
                return true;
            }
            else
            {
                return entity.Name != name;
            }
        }

        public override bool Equals(object obj)
        {
            if (obj is IssueStatus other)
            {
                return string.Equals(this.Id, other.Id)
                    && string.Equals(this.Name, other.Name)
                    && Equals(this.StatusCategory, other.StatusCategory);
            }

            return false;
        }

        public override int GetHashCode()
        {
            unchecked
            {
                int hash = 17;
                hash = hash * 23 + (this.Id != null ? this.Id.GetHashCode() : 0);
                hash = hash * 23 + (this.Name != null ? this.Name.GetHashCode() : 0);
                hash = hash * 23 + (this.StatusCategory != null ? this.StatusCategory.GetHashCode() : 0);

                return hash;
            }
        }
    }
}
