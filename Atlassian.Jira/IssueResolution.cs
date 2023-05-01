using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Atlassian.Jira.Remote;

namespace Atlassian.Jira
{
    /// <summary>
    /// The resolution of the issue as defined in JIRA
    /// </summary>
    public class IssueResolution : JiraNamedEntity
    {
        /// <summary>
        /// Creates an instance of the IssueResolution based on a remote entity.
        /// </summary>
        public IssueResolution(AbstractNamedRemoteEntity remoteEntity)
            : base(remoteEntity)
        {
        }

        /// <summary>
        /// Creates an instance of the IssueResolution with the given id and name.
        /// </summary>
        public IssueResolution(string id, string name = null)
            : base(id, name)
        {
        }

        protected override async Task<IEnumerable<JiraNamedEntity>> GetEntitiesAsync(Jira jira, CancellationToken token)
        {
            var results = await jira.Resolutions.GetResolutionsAsync(token).ConfigureAwait(false);
            return results as IEnumerable<JiraNamedEntity>;
        }

        /// <summary>
        /// Allows assignation by name
        /// </summary>
        public static implicit operator IssueResolution(string name)
        {
            if (name != null)
            {
                if (int.TryParse(name, out _))
                {
                    return new IssueResolution(name);
                }
                else
                {
                    return new IssueResolution(null, name);
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
        public static bool operator ==(IssueResolution entity, string name)
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
        public static bool operator !=(IssueResolution entity, string name)
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
            if (obj is IssueResolution entity)
            {
                return string.Equals(this.Id, entity.Id) && string.Equals(this.Name, entity.Name);
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

                return hash;
            }
        }
    }
}
