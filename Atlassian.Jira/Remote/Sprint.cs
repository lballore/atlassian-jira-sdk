using System;


namespace Atlassian.Jira.Remote
{
    internal class Sprint
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string State { get; set; }

        public int BoardId { get; set; }

        public string Goal { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        public DateTime CompleteDate { get; set; }
    }
}
